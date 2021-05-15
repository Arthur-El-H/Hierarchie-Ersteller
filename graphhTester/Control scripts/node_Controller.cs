using System;
using System.Collections.Generic;
using System.Drawing;

namespace graphhTester
{
    public class node_Controller: IControl
    {
        private mainscreen_form mainForm; 
        public void setMainForm (mainscreen_form form) { mainForm = form; }
        private Depthtracker depthtracker;
        public void setDepthtracker(Depthtracker dt) { depthtracker = dt; }
        private hierarchy_Viewer hierarchyV;
        public void setHierarchyV(hierarchy_Viewer hV) { hierarchyV = hV; }
        private visuals_Controller visController;
        public void setVisController(visuals_Controller vC) { visController = vC; }

        private List<Node_Model> toTest;
        private Node_Model newElement;
        private Node_Model testedParent;
        private Node_Model tested;
        public  Node_Model masterNode;

        int depthCounter = 1;
        int testCounter;
        public bool levelFound;


        public void startTesting(String name, Node_Model receiver)
        {
            getNewElement(new Node_Model(name, depthtracker));
            newElement.parent = masterNode; //10.5.
            testList(receiver.children);
            testedParent = receiver;
            testNext(1);
        }
        private void getNewElement(Node_Model node)
        {
            newElement = node;
        }

        private void testList(List<Node_Model> testNodes)
        {            
            toTest = new List <Node_Model> (testNodes);
        }

        public void testNext(int state)
        {
            switch (state)
            {
                case 1:
                    if (toTest.Count < testCounter + 1) { insertFirstElement(); break; } //there is no next
                    tested = toTest[testCounter];
                    testCounter++;
                    putToTest(1);
                    break;
                case 2:
                    if (toTest.Count < testCounter + 1) { clearUp(); break; } //there is no next and level is already found
                    tested = toTest[testCounter];
                    testCounter++;
                    putToTest(2);
                    break;
            }
        }

        public void insertFirstElement()
        {
            if (depthtracker.getDepth() < depthCounter) { depthtracker.addNewRow(); }
            insert();
        }

        public void putToTest(int state)
        {
            switch (state) 
            {
                case 1:
                    mainForm.poseQuestion(newElement, tested);
                    mainForm.enableButtons(true);
                    mainForm.setButtonState(state);
                    break;
                case 2:
                    mainForm.poseQuestion(tested, newElement);
                    mainForm.enableButtons(true);
                    mainForm.setButtonState(state);
                    break;
            }
        }

        public void goDeeper()     //call if yes after first putToTest
        {
            testCounter = 1;
            testedParent = tested;
            depthCounter++;
            if(depthtracker.getDepth() < depthCounter) {  depthtracker.addNewRow(); }
            testList(tested.children);
            if(toTest.Count == 0) { insert(); return; }
            tested = toTest[0];
            putToTest(1);
        }

        public void startInsertingAsParent()
        {
            levelFound = true;
            newElement.parent = testedParent;
            newElement.depth = depthCounter;
            if (depthtracker.getDepth() <= newElement.depth) { depthtracker.addNewRow(); }
            depthtracker.addToRow(newElement.depth - 1, newElement);
            testedParent.children.Add(newElement);
            visController.createRep(newElement, true);
            insertAsParentAndGoToNext(true);

            visController.drawArrow(newElement.nodeRep.Top, testedParent.nodeRep.Bottom);
            visController.drawArrow(tested.nodeRep.Top, newElement.nodeRep.Bottom);
        }

        private void setBelow(Node_Model node)
        {
            depthtracker.remove(node);
            node.depth++;
            if (depthtracker.getDepth() <= node.depth) { depthtracker.addNewRow(); }
            depthtracker.addToRow(node.depth - 1, node);
        }
        public void insertAsParentAndGoToNext(bool firstTime = false)     //call if yes after first putToTest
        {
            testedParent.children.Remove(tested);
            tested.parent = newElement;
            setBelow(tested);
            foreach (Node_Model node in tested.includes())
            {
                setBelow(node);
            }
            newElement.children.Add(tested);
            hierarchyV.insertRepAsParent(newElement.nodeRep, tested.nodeRep, !firstTime);

            visController.drawArrow(newElement.nodeRep.Top, testedParent.nodeRep.Bottom);
            visController.drawArrow(tested.nodeRep.Top, newElement.nodeRep.Bottom);

            visController.deleteAllArrows();
            visController.redrawAllArrows();

            testNext(2);
        }

        private void insert()
        {
            testedParent.children.Add(newElement);
            newElement.parent = testedParent;
            newElement.depth = depthCounter;
            depthtracker.addToRow(depthCounter - 1, newElement);
            visController.createRep(newElement);
            visController.drawArrow(newElement.nodeRep.Top, testedParent.nodeRep.Bottom) ;
            clearUp();
        }

        private void clearUp()
        {
            depthCounter = 1;
            testCounter = 0;
            levelFound = false;
            mainForm.enableAddElement(true);
            mainForm.setButtonState(1);
            mainForm.clearNewNodeqst();

            visController.deleteAllArrows();
            visController.redrawAllArrows();
        }
    }
}
