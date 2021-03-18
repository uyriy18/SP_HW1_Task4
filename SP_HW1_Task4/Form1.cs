
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Management;    // Add a reference to System.Management.

namespace SP_HW1_Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int NumProcesses, NumThreads;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            trvProcesses.Nodes.Clear();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Dictionary<int, ProcessInfo> process_dict =
                new Dictionary<int, ProcessInfo>();

            // Get the processes.
            foreach (Process process in Process.GetProcesses())
            {
                process_dict.Add(process.Id, new ProcessInfo(process));
            }

            // Get the parent/child info.
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
               "SELECT ProcessId, ParentProcessId FROM Win32_Process");
            ManagementObjectCollection collection = searcher.Get();

            // Create the child lists.
            foreach (var item in collection)
            {
                // Find the parent and child in the dictionary.
                int child_id = Convert.ToInt32(item["ProcessId"]);
                int parent_id = Convert.ToInt32(item["ParentProcessId"]);

                ProcessInfo child_info = null;
                ProcessInfo parent_info = null;
                if (process_dict.ContainsKey(child_id))
                    child_info = process_dict[child_id];
                if (process_dict.ContainsKey(parent_id))
                    parent_info = process_dict[parent_id];

                if (child_info == null)
                    Console.WriteLine(
                        "Cannot find child " + child_id.ToString() +
                        " for parent " + parent_id.ToString());

                if (parent_info == null)
                    Console.WriteLine(
                        "Cannot find parent " + parent_id.ToString() +
                        " for child " + child_id.ToString());

                if ((child_info != null) && (parent_info != null))
                {
                    parent_info.Children.Add(child_info);
                    child_info.Parent = parent_info;
                }
            }

            // Convert the dictionary into a list.
            List<ProcessInfo> infos = process_dict.Values.ToList();

            // Sort the list.
            infos.Sort();

            // Populate the TreeView.
            NumProcesses = 0;
            NumThreads = 0;
            foreach (ProcessInfo info in infos)
            {
                // Start with root processes.
                if (info.Parent != null) continue;

                // Add this process to the TreeView.
                AddInfoToTree(trvProcesses.Nodes, info);
            }
            lblCounts.Text =
                "# Processes: " +
                NumProcesses.ToString() + ", " +
                "# Threads : " +
                NumThreads.ToString();

            watch.Stop();
            Console.WriteLine(string.Format("{0:0.00} seconds",
                watch.Elapsed.TotalSeconds));
        }

        // Add a ProcessInfo, its children, and its threads to the tree.
        private void AddInfoToTree(TreeNodeCollection nodes, ProcessInfo info)
        {
            // Add the process's node.
            TreeNode process_node = nodes.Add(info.ToString());
            process_node.Tag = info;
            NumProcesses++;

            // Add the node's threads.
            if (info.TheProcess.Threads.Count > 0)
            {
                TreeNode thread_node = process_node.Nodes.Add("Threads");
                foreach (ProcessThread thread in info.TheProcess.Threads)
                {
                    thread_node.Nodes.Add(string.Format(
                        "Thread {0}", thread.Id));
                    NumThreads++;
                }
            }

            // Sort the children.
            info.Children.Sort();

            // Add child processes.
            foreach (ProcessInfo child_info in info.Children)
            {
                AddInfoToTree(process_node.Nodes, child_info);
            }

            // Expand the main process node.
            if (info.Children.Count > 0)
                process_node.Expand();
        }

        private void trvProcesses_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            string text = node.FullPath;
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(ShowInfo);
            Thread thread = new Thread(parameterized);
            thread.IsBackground = true;
            thread.Start((object)text);
        }
        private void ShowInfo(object sender)
        {
            string text = (string)sender; 
            Info_lbl.Invoke((MethodInvoker)delegate {Info_lbl.Text = text;});
        }
    }
}
