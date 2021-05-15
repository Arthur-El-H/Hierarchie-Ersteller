using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace graphhTester
{
    public class visuals_Controller: IControl
    {
        private Graphics g;
        private Pen pen;
        private Pen eraser;
        private List<Point> listOfLines = new List<Point>();

        public Node_Model masterNode;
        public NodeRepresenter_Viewer markedRep;


        private mainscreen_form mainForm;
        private hierarchy_Viewer hierarchyV;

        public visuals_Controller(hierarchy_Viewer hV, mainscreen_form form)
        {
            this.hierarchyV = hV;
            this.mainForm = form;
        }

        public void createRep(Node_Model rep, bool asParent = false, bool asRoot = false)
        {
            NodeRepresenter_Viewer noderep;
            if (asRoot)
            {
                noderep = new NodeRepresenter_Viewer(rep, true);
                hierarchyV.insertNodeRepMaster(noderep);
            }
            else
            {
                noderep = new NodeRepresenter_Viewer(rep);
                if (!asParent) hierarchyV.insertRep(noderep);
            }
            noderep.setVisController(this);
            mainForm.receiveRep(noderep);
        }
        public void createPen()
        {
            pen = new Pen(Color.FromArgb(198, 196, 221), 3);
            g = mainForm.getHierarchyPanel().CreateGraphics();
            createEraser();
        }
        private void createEraser()
        {
            eraser = new Pen(Color.FromArgb(23, 34, 59), 3);
        }
        public void drawArrow(Point A, Point B, bool erase = false)
        {
            if (erase) { g.DrawLine(eraser, A, B); return; }
            listOfLines.Add(A);
            listOfLines.Add(B);
            g.DrawLine(pen, A, B);
        }
        public void deleteAllArrows()
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < listOfLines.Count / 2; i++)
            {
                drawArrow(listOfLines[a], listOfLines[b], true);
                a += 2;
                b += 2;
            }
        }
        public void redrawAllArrows()
        {
            foreach (Node_Model childNode in masterNode.children)
            {
                //MessageBox.Show("count b!");
                drawArrow(childNode.nodeRep.Top, masterNode.nodeRep.Bottom);
            }

            foreach (Node_Model node in masterNode.includes())
            {

                foreach (Node_Model childNode in node.children)
                {
                    //MessageBox.Show("count b!");
                    drawArrow(childNode.nodeRep.Top, node.nodeRep.Bottom);
                }
            }
        }
        public void changeMarkedRep(NodeRepresenter_Viewer rep)
        {
            if (markedRep != null) markedRep.BackColor = markedRep.node.currentColor;
            markedRep = rep;
            rep.BackColor = Color.White;
            mainForm.setCurrentElement(rep.name);
        }
        public void showList(List<Node_Model> nodes)
        {

            foreach (Node_Model node in nodes)
            {
                mainForm.AddToShowcase(node.name);
            }
        }
    }
}
