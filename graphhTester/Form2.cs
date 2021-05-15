using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace graphhTester
{
    public partial class Form2 : Form
    {
        public Depthtracker depthtracker;
        public visualDepthTracker visDepthTracker;
        Control control;
        public Node masterNode;
        public Node varNode;
        int buttonState;

        Color equal = Color.FromArgb(255, 216, 102);
        Color include = Color.FromArgb(217, 255, 102);
        Color isPartOf = Color.FromArgb(255, 254, 102);
        Color noRelation = Color.FromArgb(255, 178, 102);
        public Form2() 
        {
            InitializeComponent();

            control = new Control();
            depthtracker = new Depthtracker();
            visDepthTracker = new visualDepthTracker();
            control.visDepthTracker = visDepthTracker;
            control.depthtracker = depthtracker;
            control.form1 = this;
            visDepthTracker.control = control;

            visDepthTracker.createNewDepth();
            createmasterNode();
            control.masterNode = masterNode;
            control.createRep(masterNode, false, true);
            control.createPen();

            yesBtn.Enabled = false;
            noBtn.Enabled = false;
            noBtn.Hide();
            yesBtn.Hide();
            newNodeqst.Hide();

            listShowCase.View = View.List;
            listShowCase.LabelWrap = true;           
        }
        public Panel getHierarchyPanel()
        {
            return hierarchyPanel;
        }
        public void receiveRep(Label nodeRep)
        {
            hierarchyPanel.Controls.Add(nodeRep);            
        }
        public void AddToShowcase(string element)
        {
            ListViewItem item = new ListViewItem();
            item.Text = element;
            listShowCase.Items.Add(item);
        }
        void createmasterNode()
        {
            masterNode = new Node("Root", depthtracker);
            masterNode.form1 = this;
            depthtracker.addNewRow();
            depthtracker.addToRow(0,masterNode);
        }
        public void poseQuestion(Node child, Node parent)
        {
            newNodeqst.Visible = true;
            newNodeQstPanel.Visible = true;
            newNodeqst.Text = "Is " + child.name + " a " + parent.name;
            yesBtn.Enabled = true;
            noBtn.Enabled = true;
        }
        public void clearNewNodeqst()
        {
            newNodeqst.Text = "";
            newNodeqst.Visible = false;
            newNodeQstPanel.Visible = false;
        }
        public void enableButtons(bool enable)
        {
            if (enable) { yesBtn.Show(); noBtn.Show(); newNodeqst.Show(); }
            else
            { noBtn.Hide(); yesBtn.Hide(); newNodeqst.Hide(); }
            yesBtn.Enabled = enable;
            noBtn.Enabled = enable;
        }
        public void enableAddElement(bool enable)
        {
            newElementBtn.Enabled = enable;
        }
        public void setButtonState(int state)
        {
            buttonState = state;
        }
        public void setCurrentElement(string name)
        {
            currentElement.Text = name;
        }

        private void newElementBtn_Click(object sender, EventArgs e)
        {
            control.startTesting(elementInput.Text, masterNode);
        }
        private void insertAsChildBtn_Click(object sender, EventArgs e)
        {
            control.startTesting(elementInput.Text, control.markedRep.node);
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            switch (buttonState)
            {
                case 1: enableButtons(false); control.goDeeper(); break;
                case 2: enableButtons(false); 
                    if (control.levelFound)
                    {
                        control.insertAsParentAndGoToNext();
                    }
                    else { control.startInsertingAsParent(); } break;
            }
        }
        private void noBtn_Click(object sender, EventArgs e)
        {
            switch (buttonState)
            {
                case 1: enableButtons(false); control.putToTest(2); break;
                case 2: enableButtons(false); if (control.levelFound) { control.testNext(2); } else control.testNext(1); break;
            }
        }

        private void testBtn_Click_1(object sender, EventArgs e)
        {
            listShowCase.Clear();
            control.startTesting("Kleidung", masterNode);
            control.startTesting("Poloshirt", masterNode);
            yesBtn_Click(sender, e);
            control.startTesting("Festnetz", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            control.startTesting("iPhone 12", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            control.startTesting("grün", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            control.startTesting("Elektronik", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            control.startTesting("T-Shirts", masterNode);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            control.startTesting("Oberbekleidung", masterNode);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            control.startTesting("Telefone", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            
            control.startTesting("black", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            control.startTesting("Unterbekleidung", masterNode);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            control.startTesting("Softshelljacke blau M", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            
            control.startTesting("iPhone 12 64GB", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            control.startTesting("Poloshirt", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            control.startTesting("Poloshirt grün L", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            
            control.startTesting("Softshelljacke blau", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);                        
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            
            control.startTesting("Smartphones", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            control.startTesting("Silver", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            control.startTesting("grün M", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            //control.startTesting("Jacken", masterNode);



        }

        private void includeBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node> nodes = new List<Node>();
            nodes = control.markedRep.node.includes();
            visDepthTracker.markList(nodes, include);
            control.showList(nodes);
        }
        private void isPartOfBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node> nodes = control.markedRep.node.isPartOf();
            visDepthTracker.markList(nodes, isPartOf);
            control.showList(nodes);
        }
        private void isEqualToBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node> nodes = new List<Node>();
            nodes = control.markedRep.node.isEqualTo();
            visDepthTracker.markList(nodes, equal);
            control.showList(nodes);
        }
        private void noRelationToBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node> nodes = new List<Node>();
            nodes = control.markedRep.node.hasNoRelationTo();
            visDepthTracker.markList(nodes, noRelation);
            control.showList(nodes);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
