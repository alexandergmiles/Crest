using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Crest.Data;
using Crest;
using Crest.Data.Exceptions;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Crest.Data.Projects;
using Crest.Data.Interfaces;

namespace Crest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProjectSaving()
        {
            string path = "";
            using (var folderBrowsingDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowsingDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowsingDialog.SelectedPath))
                    path = folderBrowsingDialog.SelectedPath;
            }
            path += "/newProject.prj";
            ProjectFactory projectFactory = new ProjectFactory();
            CSharpProject project = new CSharpProject("Aurora", "Agmiles", new List<string> { "C#" });
            Assert.AreEqual(true, projectFactory.SaveProject(path, project));
        }

        [TestMethod]
        public void TestProjectLoading()
        {
            Stream loadStream = null;
            string result = "";
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Project files | *.prj",
                FilterIndex = 1,
                RestoreDirectory = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((loadStream = openFileDialog.OpenFile()) != null)
                        using (StreamReader reader = new StreamReader(loadStream))
                        {
                            result = reader.ReadToEndAsync().Result;
                        }
                }
                catch (Exception e)
                {

                }
            }
            ProjectFactory projectFactory = new ProjectFactory();
            CSharpProject loadedProject = projectFactory.LoadProject<CSharpProject>(result);
            CSharpProject project = new CSharpProject("Aurora", "Agmiles", new List<string> { "C#" });
            Assert.AreEqual(project.ProjectType, loadedProject.ProjectType);
        }
    }
}
