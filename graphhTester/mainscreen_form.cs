using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace graphhTester
{
    public partial class mainscreen_form : Form
    {
        private Depthtracker depthtracker;
        private hierarchy_Viewer hierarchyV;
        private node_Controller node_Controller;
        private visuals_Controller visController;

        private Node_Model masterNode;
        private Node_Model varNode;
        private int buttonState;

        private Color equal = Color.FromArgb(255, 216, 102);
        private Color include = Color.FromArgb(217, 255, 102);
        private Color isPartOf = Color.FromArgb(255, 254, 102);
        private Color noRelation = Color.FromArgb(255, 178, 102);

        public mainscreen_form() 
        {
            InitializeComponent();

            node_Controller = new node_Controller();
            depthtracker = new Depthtracker();
            hierarchyV = new hierarchy_Viewer();
            visController = new visuals_Controller(hierarchyV, this);
            node_Controller.setHierarchyV(hierarchyV);
            node_Controller.setDepthtracker(depthtracker);
            node_Controller.setMainForm(this);
            node_Controller.setVisController(visController);

            hierarchyV.createNewDepth();
            createmasterNode();
            visController.masterNode = masterNode;
            node_Controller.masterNode = masterNode;
            visController.createRep(masterNode, false, true);
            visController.createPen();

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
        private void createmasterNode()
        {
            masterNode = new Node_Model("Root", depthtracker);
            depthtracker.addNewRow();
            depthtracker.addToRow(0,masterNode);
        }
        public void poseQuestion(Node_Model child, Node_Model parent)
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
            node_Controller.startTesting(elementInput.Text, masterNode);
        }
        private void insertAsChildBtn_Click(object sender, EventArgs e)
        {
            node_Controller.startTesting(elementInput.Text, visController.markedRep.node);
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            switch (buttonState)
            {
                case 1: enableButtons(false); node_Controller.goDeeper(); break;
                case 2: enableButtons(false); 
                    if (node_Controller.levelFound)
                    {
                        node_Controller.insertAsParentAndGoToNext();
                    }
                    else { node_Controller.startInsertingAsParent(); } break;
            }
        }
        private void noBtn_Click(object sender, EventArgs e)
        {
            switch (buttonState)
            {
                case 1: enableButtons(false); node_Controller.putToTest(2); break;
                case 2: enableButtons(false); if (node_Controller.levelFound) { node_Controller.testNext(2); } else node_Controller.testNext(1); break;
            }
        }

        private void testBtn_Click_1(object sender, EventArgs e)
        {
            listShowCase.Clear();
            node_Controller.startTesting("Kleidung", masterNode);
            node_Controller.startTesting("Poloshirt", masterNode);
            yesBtn_Click(sender, e);
            node_Controller.startTesting("Festnetz", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            node_Controller.startTesting("iPhone 12", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            node_Controller.startTesting("grün", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            node_Controller.startTesting("Elektronik", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            node_Controller.startTesting("T-Shirts", masterNode);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            node_Controller.startTesting("Oberbekleidung", masterNode);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            node_Controller.startTesting("Telefone", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);


            node_Controller.startTesting("black", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            node_Controller.startTesting("Unterbekleidung", masterNode);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);

            node_Controller.startTesting("Softshelljacke blau M", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);


            node_Controller.startTesting("iPhone 12 64GB", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            node_Controller.startTesting("Poloshirt", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            node_Controller.startTesting("Poloshirt grün L", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);


            node_Controller.startTesting("Softshelljacke blau", masterNode);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);                        
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);


            node_Controller.startTesting("Smartphones", masterNode);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            yesBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            noBtn_Click(sender, e);
            yesBtn_Click(sender, e);

            node_Controller.startTesting("Silver", masterNode);
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

            node_Controller.startTesting("grün M", masterNode);
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
            List<Node_Model> nodes = new List<Node_Model>();
            nodes = visController.markedRep.node.includes();
            hierarchyV.markList(nodes, include);
            visController.showList(nodes);
        }
        private void isPartOfBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node_Model> nodes = visController.markedRep.node.isPartOf();
            hierarchyV.markList(nodes, isPartOf);
            visController.showList(nodes);
        }
        private void isEqualToBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node_Model> nodes = new List<Node_Model>();
            nodes = visController.markedRep.node.isEqualTo();
            hierarchyV.markList(nodes, equal);
            visController.showList(nodes);
        }
        private void noRelationToBtn_Click(object sender, EventArgs e)
        {
            listShowCase.Items.Clear();
            List<Node_Model> nodes = new List<Node_Model>();
            nodes = visController.markedRep.node.hasNoRelationTo();
            hierarchyV.markList(nodes, noRelation);
            visController.showList(nodes);
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
