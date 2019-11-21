using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSearcher
{
    public partial class MainForm : Form
    {
        static string[] separator = {" ", "\t", "\r", "\n"};
        static List<string> notFound = new List<string>();
        public MainForm()
        {
            InitializeComponent();
        }
        #region Select Buttons Functions
        private void BTN_SelectSource_Click(object sender, EventArgs e)
        {
            DialogResult result = openSourceFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TB_Source.Text = openSourceFolderDialog.SelectedPath;
            }
        }
        private void BTN_SelectTarget_Click(object sender, EventArgs e)
        {
            DialogResult result = openTargetFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TB_Target.Text = openTargetFolderDialog.SelectedPath;
            }
        }
        #endregion

        #region Support functions for Prepare List<string> candidates
        private string[] getSourceList()
        {
            string[] allFiles;
            try
            {
                allFiles = Directory.GetFiles(TB_Source.Text, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in getting source list");
                return null;
            }
            return allFiles;
        }
        private List<List<string>> getParamList()
        {
            List<List<string>> paramList = new List<List<string>>();
            try
            {
                string[] lines = TB_NameList.Text.Split('\n');
                foreach (string line in lines)
                {
                    if (line.Trim().Length == 0) //empty row
                    {
                        continue;
                    }
                    List<string> lineParams = new List<string>();
                    string[] tokens = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string token in tokens)
                    {
                        if (token.Trim().Length > 0)
                        {
                            lineParams.Add(token);
                        }
                    }
                    if (lineParams.Count > 0)
                    {
                        paramList.Add(lineParams);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in getting search parameters list");
                return null;
            }
            return paramList;
        }
        private bool matchAll(List<string> tokens, string str)
        {
            foreach(string t in tokens)
            {
                if (CB_Case.Checked) //case sensitive, full check
                {
                    if (!str.Contains(t))
                    {
                        return false;
                    }
                }
                else
                {                    
                    if (!(str.ToLower()).Contains(t.ToLower()))
                    {
                        return false;
                    }
                }                
            }
            return true;
        }
        private string listToString(List<string> strList)
        {
            string result = "";
            foreach (string s in strList)
            {
                result += s;
                result += " ";
            }
            return result;
        }
        private List<string> getCandidates(List<List<string>> paramsList, string[] sourceList)
        {
            List<string> candidates = new List<string>();
            try
            {
                foreach (List<string> lineParams in paramsList)
                {
                    bool foundSomething = false;
                    foreach (string file in sourceList)
                    {
                        if (matchAll(lineParams, file))
                        {
                            candidates.Add(file);
                            foundSomething = true;
                        }
                    }
                    if (!foundSomething)
                    {
                        notFound.Add(listToString(lineParams));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in getting candidate list");
                return null;
            }
            return candidates;
        }
        #endregion
        private void removeCandidate(string s, List<string> sList)
        {
            List<int> removalIndex = new List<int>();
            for (int i = 0; i < sList.Count; i++)
            {
                string fullfileName = sList[i];
                string shortfileName = fullfileName.Substring(fullfileName.LastIndexOf("\\"));                
                if (s.Equals(shortfileName, StringComparison.OrdinalIgnoreCase))
                {
                    removalIndex.Add(i);
                }
            }
            foreach (int i in removalIndex)
            {
                sList[i] = "";
            }
        }
        private List<string> findDuplicates(List<string> candidates)
        {
            List<string> duplicates = new List<string>(); //list of files (short name) that are duplicates
            try
            {
                //find
                List<string> shortList = new List<string>();
                foreach (string fullFileName in candidates)
                {
                    string shortfileName = fullFileName.Substring(fullFileName.LastIndexOf("\\"));
                    foreach (string s in shortList)
                    {
                        if (s.Equals(shortfileName))
                        {
                            duplicates.Add(shortfileName);                            
                        }
                    }
                    shortList.Add(shortfileName);
                }
                //remove
                if (duplicates.Count > 0)
                {
                    foreach (string dup in duplicates)
                    {
                        removeCandidate(dup, candidates);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unexpected Error in file duplication verification process");
                return null;
            }
            
            return duplicates;
        }
        private bool moveFile(string fileName)
        {
            try
            {
                string fileShortName = fileName.Substring(fileName.LastIndexOf("\\"));
                File.Copy(fileName, TB_Target.Text + fileShortName);
            } catch (Exception)
            {
                return false;
            }            
            return true;
        }

        private void BTN_Run_Click(object sender, EventArgs e)
        {
            #region Prepare List<string> candidates
            string[] masterSourceList = getSourceList();
            if (masterSourceList == null)
            {
                MessageBox.Show("Unable to locate source folder");
                return;
            }

            List<List<string>> paramList = getParamList();
            if (paramList == null)
            {
                MessageBox.Show("Invalid Name List");
                return;
            }

            List<string> candidates = getCandidates(paramList, masterSourceList);
            if (candidates == null)
            {
                MessageBox.Show("Error retrieving candidate files");
                return;
            }
            #endregion

            List<string> duplicates = findDuplicates(candidates);
            if (duplicates == null)
            {
                return;
            }            
            // Move files
            List<string> failed = new List<string>();
            foreach (string file in candidates)
            {
                if (file.Length == 0) continue;
                bool status = moveFile(file);
                if (!status)
                {
                    failed.Add(file);
                }
            }            
            if (duplicates.Count > 0 || failed.Count > 0 || notFound.Count > 0)
            {
                displayResult(notFound, duplicates, failed);                
                MessageBox.Show("Not all operations were successful. Please check textbox for details");
            } 
            else
            {
                MessageBox.Show("All " + candidates.Count + " file(s) found and moved successfully", "Success!");
            }            
        }
        private void displayResult(List<string> notFound, List<string> duplicates, List<string> failed)
        {
            string resultText = "";
            resultText = "==== " + notFound.Count + " not found ====";
            resultText += "\r\n";
            foreach (string s in notFound)
            {
                resultText += s;
                resultText += "\r\n";
            }
            resultText += "==== " + duplicates.Count + " duplicates found ====";
            resultText += "\r\n";
            foreach (string s in duplicates)
            {
                resultText += s;
                resultText += "\r\n";
            }
            resultText += "==== " + failed.Count + " failed to move ====";
            resultText += "\r\n";
            foreach (string s in failed)
            {
                resultText += s;
                resultText += "\r\n";
            }
            TB_NameList.Clear();
            TB_NameList.AppendText(resultText);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //try to look for config file
            try
            {
                string[] lines = File.ReadAllLines("C:\\Users\\" + Environment.UserName + "\\Desktop\\FSO.config");
                TB_Source.Text = lines[0];
                TB_Target.Text = lines[1];
            } catch (Exception)
            {
                MessageBox.Show("No config file found. You can place one on your desktop with name FSO.config");
            }
        }

        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            TB_NameList.Clear();
        }
    }
}
