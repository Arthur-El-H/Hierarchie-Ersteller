using System;

public class Node
{
    Node parent;
    List < Node > children;

    List < Node > included = new List < Node > ();

    int childrensDepth;
    int depth;
    int amountOfIncluded;
    public bool imaginary;

    public Depthtracker depthtracker;

    int parentDegreeCounter;
    List<Node> isPartOf ( List < Node > outputNodes )  
    {
        outputNodes.Add ( parent );
        parentDegreeCounter++;
        if (parent.parent != null)
        {
            outputNodes = ( parent.parent ) .isPartOf ( outputNodes );
        }
        else
        {
            parentDegreeCounter = 0;
            return ( outputNodes );
        }
    }

    //potentiell zu Array, wenn childrensChildren getrackt würde (z.B. durch int bei jedem node und eins hochzählen bei parentParents nach Aufnahme neues Nodes
    List < Node > includes ( List < Node > output )
    {
        foreach ( Node child in children )
        {
            output.Add ( child.includes ( output ) );           
        }
        return output;
    }

    Node getParent(int degree , Node output)
    {
        output = this;
        for ( int i = 0 ; i < degree ; i++ )
        {
            output = output.parent;
        }
        return output;
    }

    List < ( Node , int ) > isEqualTo ( List < Node , int > outWeightedputNode )                        // Gibt sich selbst mit wert 0 zurück: Gut für markieren.
    {
        List < Node > nodesToCheck = new List < Node > ( depthtracker.getDepth ( depth ) );

        for ( int f = 0 ; f + 1 < depth ; f++ )                                                         // Würde es bis depth gehen ( f<=depth), würde der oberste imaginäre mitbedacht werden.
        {
            for (int i = 0; i < nodesToCheck.Count; i++)
            {
                if (nodesToCheck [ i ] .parent == this.parent) 
                {
                    outputWeightedNode.Add ( nodesToCheck [ i ]  , f );
                    nodesToCheck.RemoveAt ( i ) ; 
                }
            }
        }

    }

    List<Node> hasNoRelationTo(List<Node> output)
    {
        Node varNode = this.getParent(depth - 1, parent);
        List<Node, int> parentsEquals = new List<Node>(varNode.isEqualTo(parentsEquals));

        for (int i = 0; i < parentsEquals.Count; i++)
        {
            varNode = parentsEquals[i];
            if (!(varNode.Item2 == 0))
            {
                output.Add(varNode.Item1.includes());
                output.Add(varNode.Item1);
            }
        }
        return output;
    }

    
    void getNewNode(Node receivingNode, Node newElement, int depthCounter = 0, bool levelFound = false)
    {
        depthCounter++;
        foreach (Node child in children)
        {
            if (newElement.isChildOf(child) && !levelFound)
            {
                child.amountOfIncluded++;
                child.getNewNode(child, newElement);
                return;
            }

            if (child.isChildOf(newElement))
            {
                levelFound = true;
                child.parent.children.Remove(child);
                child.setParent(newElement);
                newElement.setChild(child);
            }
        }
        receivingNote.children.Add(newElement);
        newElement.setParent(receivingNode);
        
        depthtracker.depthRows[depthCounter].Add(newElement);
        newElement.depth = depthCounter;
    }

    void setParent( Node newParent ) { parent = newParent; }
    void setChild (Node newChild)    { children.Add(newChild); }
}
