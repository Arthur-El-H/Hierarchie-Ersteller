﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace graphhTester
{
    public class visualDepthTracker
    {
        List <List<NodeRepresenter>> visualTree = new List<List<NodeRepresenter>>();
        List <int> amountOfRows = new List<int>();
        List<Point> pointForDepth = new List<Point>(); //holds (0/0) for every depth

        int verticalDistance = 80;
        int horizontalDistance = 150;

        public NodeRepresenter masterRep;
        public Control control;

        public void insertNodeRepMaster(NodeRepresenter master)
        {
            master.lastChildIndex = 0;
            master.depth = 0;
            visualTree[0].Add(master);
            masterRep = master;
        }
        int correctedIndex(NodeRepresenter rep)
        {
            int index = 0;
            int index_ = visualTree[rep.depth].FindIndex(a => a == rep);
            for (int i = 0; i < index_; i++)
            {
                {
                    foreach (NodeRepresenter child in visualTree[rep.depth][i].children)
                    {
                        if (visualTree[rep.depth + 1].Contains(child))
                        {
                            index++;
                        }
                    }
                }
            }
            return index;
        }

        List<Node> toNotCheck = new List<Node>();
        NodeRepresenter new_Child; //10.5.

        public void insertRepAsParent(NodeRepresenter rep, NodeRepresenter newChild, bool notFirstTime = true)
        {
            rep.children.Add(newChild);
            new_Child = newChild;

            
            toNotCheck = newChild.node.includes();

            int repIndex = getRepIndex(newChild);
            for (int i = repIndex; i < visualTree[newChild.depth].Count; i++)
            {
                visualTree[newChild.depth][i].lastChildIndex -= newChild.children.Count;
            }
            for (int i = getRepIndex(rep.parent); i < visualTree[rep.parent.depth].Count; i++)
            {
                visualTree[rep.parent.depth][i].lastChildIndex --;
            }
            if (!notFirstTime) { insertRep(rep, true, repIndex); }
            
            removeFromDepth(newChild);

            newChild.parent.children.Remove(newChild);
            newChild.parent = rep;

            insertRep(newChild);

            foreach (Node node in toNotCheck)
            {
                removeFromDepth(node.nodeRep);
                node.nodeRep.depth = 0;
                insertRep(node.nodeRep);
            }
        }
        int getRepIndex(NodeRepresenter noderep)
        {
            return visualTree[noderep.depth].FindIndex(a => a == noderep);
        }
        void removeFromDepth(NodeRepresenter noderep, NodeRepresenter rep = null) //in visual tree only - parenthood/childhood is organized seperately
        {
                int index = visualTree[noderep.parent.depth].FindIndex(a => a == noderep.parent);
                visualTree[noderep.depth].Remove(noderep);
                for (int i = index; i < visualTree[noderep.parent.depth].Count; i++)
                {
                    if (!(toNotCheck.Contains(visualTree[noderep.parent.depth][i].node) || visualTree[noderep.parent.depth][i] == new_Child))
                    {
                        for (int j = 0; j < noderep.children.Count; j++)
                        {
                        if (visualTree[noderep.parent.depth][i].lastChildIndex > 0)
                        {
                            visualTree[noderep.parent.depth][i].lastChildIndex--;
                        }
                        }                    
                    }
                }
            replaceDepth(noderep.depth);
        }
        public void insertRep(NodeRepresenter repC, bool specificIndex = false, int index = 0)
        {
            repC.depth = repC.parent.depth + 1;
            Debug.WriteLine(repC.parent.name + "oder was");
            if (repC.depth >= visualTree.Count) { createNewDepth(); }
            //if (amountOfRows[rep.depth]*8 < visualTree[rep.depth].Count + 1) { giveNewRowTo(rep.depth); }
            if (specificIndex) { placeInDepth(repC, specificIndex, index); }
            else { placeInDepth(repC); }
        }
        public void createNewDepth()
        {
            visualTree.Add(new List<NodeRepresenter>());
            amountOfRows.Add(1);
            int pointY = 40;
            Debug.WriteLine(amountOfRows.Count);
            for (int i = 1; i < amountOfRows.Count; i++) { pointY = pointY + verticalDistance; }
            Debug.WriteLine(pointY + "is too big?");
            pointForDepth.Add(new Point(30, pointY));
        }
        private void placeInDepth(NodeRepresenter rep, bool specificIndex = false, int index = 0)
        {
            int index_ = visualTree[rep.parent.depth].FindIndex(a => a == rep.parent);
            
            if (specificIndex) 
            {
                { visualTree[rep.depth].Insert(index, rep); }
            }
            else if (visualTree[rep.depth].Count == 0) 
            { 
                visualTree[rep.depth].Add(rep); 
            }
            else if (rep.parent.lastChildIndex > visualTree[rep.depth].Count) 
            { 
                visualTree[rep.depth].Add(rep);
            }
            else if (visualTree[rep.depth].Count  == rep.parent.lastChildIndex) 
            { 
                visualTree[rep.depth].Add(rep);
            }
            else 
            {
                visualTree[rep.depth].Insert(rep.parent.lastChildIndex, rep); //10.5.
            }


            for (int i = index_; i < visualTree[rep.parent.depth].Count; i++)
            {
                {   visualTree[rep.parent.depth][i].lastChildIndex++; }
            }            

            replaceDepth(rep.depth);

            rep.lastChildIndex = correctedIndex(rep);
        }
        private void replaceDepth(int depth)
        {
            for (int i = 0; i < visualTree[depth].Count; i++)
            {
                Point newLoc = new Point(i * horizontalDistance + pointForDepth[depth].X,
                                         pointForDepth[depth].Y);
                visualTree[depth][i].Location = newLoc;

                //set anchorpoints
                visualTree[depth][i].Bottom = new Point(newLoc.X + 50, newLoc.Y + 40);
                visualTree[depth][i].Top =    new Point(newLoc.X + 50, newLoc.Y);
            }
        }

        List <Node> markedNodes = new List<Node>();
        Color standartColor = Color.FromArgb(198, 196, 221);
        public void markList(List<Node> nodes, Color color)
        {
            colornodesList(markedNodes, standartColor);
            markedNodes = nodes;
            colornodesList(nodes, color);
        }
        public void colornodesList(List<Node> nodes, Color color)
        {
            foreach(Node node in nodes)
            {
                node.nodeRep.BackColor = color;
                node.currentColor = color;
            }
        }
    }
}
