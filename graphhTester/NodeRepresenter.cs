using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace graphhTester
{
    public class NodeRepresenter : Label
    {        
        public String name;
        public int[] Pos;
        public Label isAChildOf;
        public List<NodeRepresenter> children = new List<NodeRepresenter>() ;
        public NodeRepresenter parent;
        public Control control;
        public bool movedAlready;
        Color noderepColor = Color.FromArgb(255, 198, 196, 221);
        Color rootColor = Color.FromArgb(255, 103, 104);

        public Point Bottom;
        public Point Top;

        public Node node; 

        public int lastChildIndex = 0;
        public int depth;

        public int verticalDistance = 80;
        public int horizontalDistance = 200;

        Point masterLoc = new Point(300, 20);
        Point masterBottom = new Point(350, 60);

        public NodeRepresenter(Node _node, bool root = false)
        {
            BackColor = noderepColor;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Segeo UI", 12);
            Size = new Size(horizontalDistance / 2, verticalDistance / 2);
            BringToFront();
            Visible = true;
            name = _node.name;
            Text = name;
            node = _node;
            _node.nodeRep = this;

            if (root)
            {
                parent = null;
                Location = masterLoc;
                Bottom = masterBottom;
                BackColor = rootColor;
            }
            else
            {
                parent = node.parent.nodeRep;
                depth = _node.depth;
                parent.children.Add(this);
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (this == control.masterNode.nodeRep) { return; }
            control.changeMarkedRep(this);
        }
    }
}
