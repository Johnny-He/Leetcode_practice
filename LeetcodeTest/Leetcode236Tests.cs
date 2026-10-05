using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
// 給兩個節點 p、q，回傳它們最低（最深）的共同祖先。一個節點可以是自己的祖先。
// 節點數 2 ~ 10^5，值都不重複，p != q，且 p、q 一定在樹裡。
[TestFixture]
public class LeetCode236Tests
{
    //            3
    //         /     \
    //        5       1
    //       / \     / \
    //      6   2   0   8
    //         / \
    //        7   4
    private static readonly int?[] Example = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4];

    [Test]
    public void example1()
    {
        AssertLca(Example, p: 5, q: 1, expected: 3);
    }

    [Test]
    public void example2_a_node_can_be_its_own_ancestor()
    {
        AssertLca(Example, p: 5, q: 4, expected: 5);
    }

    [Test]
    public void example3()
    {
        AssertLca([1, 2], p: 1, q: 2, expected: 1);
    }

    [Test]
    public void p_and_q_swapped_gives_the_same_answer()
    {
        AssertLca(Example, p: 1, q: 5, expected: 3);
    }

    [Test]
    public void ancestor_is_q_and_descendant_is_p()
    {
        AssertLca(Example, p: 4, q: 5, expected: 5);
    }

    [Test]
    public void siblings_deep_in_left_subtree()
    {
        AssertLca(Example, p: 7, q: 4, expected: 2);
    }

    [Test]
    public void different_depths_under_the_same_parent()
    {
        AssertLca(Example, p: 6, q: 4, expected: 5);
    }

    [Test]
    public void lca_is_in_the_right_subtree()
    {
        AssertLca(Example, p: 0, q: 8, expected: 1);
    }

    [Test]
    public void deepest_left_node_and_right_leaf_meet_at_root()
    {
        AssertLca(Example, p: 7, q: 8, expected: 3);
    }

    //          -1
    //         /  \
    //        0    3
    //       / \
    //     -2   4
    //     /
    //    8
    [Test]
    public void negative_and_zero_values()
    {
        AssertLca([-1, 0, 3, -2, 4, null, null, 8], p: 8, q: 4, expected: 0);
    }

    //    1
    //     \
    //      2
    //       \
    //        3
    //         \
    //          4
    [Test]
    public void chain_lca_is_the_higher_node()
    {
        AssertLca([1, null, 2, null, 3, null, 4], p: 4, q: 2, expected: 2);
    }

    private static void AssertLca(int?[] levelOrder, int p, int q, int expected)
    {
        var root = TreeNodeHelper.Build(levelOrder);

        var result = new LeetCode236().LowestCommonAncestor2(root, Find(root, p), Find(root, q));

        result.Should().BeSameAs(Find(root, expected));

        var standardResult = new LeetCode236().LowestCommonAncestorStandard(root, Find(root, p), Find(root, q));

        standardResult.Should().BeSameAs(Find(root, expected));
    }

    private static TreeNode Find(TreeNode node, int val)
    {
        if (node == null || node.val == val)
        {
            return node;
        }

        return Find(node.left, val) ?? Find(node.right, val);
    }

    [Test]
    public void Method()
    {
        var treeNodes = new List<TreeNode>();
        var a = treeNodes;
        treeNodes.Add(new TreeNode(1));
        a.Count.Should().Be(1);
    }
}

public class LeetCode236
{
    private List<TreeNode> _qPathList;
    private List<TreeNode> _pPathList;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        LowestCommonAncestor(root, [], q.val, p.val);
        if (_qPathList.Count >= _pPathList.Count)
        {
            return Check2(_qPathList, _pPathList);
        }

        return Check2(_pPathList, _qPathList);
    }
    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
    {
        LowestCommonAncestor(root, [], q.val, p.val);
        if (_qPathList.Count >= _pPathList.Count)
        {
            return Check2(_qPathList, _pPathList);
        }

        return Check2(_pPathList, _qPathList);
    }

    // 標準解：一次 DFS，回傳值代表「這棵子樹裡找到的 p、q，或已經找到的 LCA」
    public TreeNode LowestCommonAncestorStandard(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)
        {
            return root;
        }

        var left = LowestCommonAncestorStandard(root.left, p, q);
        var right = LowestCommonAncestorStandard(root.right, p, q);

        if (left != null && right != null)
        {
            return root;
        }

        return left ?? right;
    }

    private TreeNode Check2(List<TreeNode> longList, List<TreeNode> shortList)
    {
        var temp = new TreeNode();
        for (var i = 0; i < shortList.Count; i++)
        {
            if (shortList[i].val == longList[i].val)
            {
                temp = shortList[i];
                continue;
            }
            break;
        }

        return temp;
    }

    private TreeNode Check(List<TreeNode> longList, List<TreeNode> shortList)
    {
        for (var i = longList.Count - 1; i >= 0; i--)
        {
            var firstOrDefault = shortList.FirstOrDefault(node => node.val == longList[i].val);
            if (firstOrDefault != null)
            {
                return firstOrDefault;
            }
        }

        return null;
    }

    private void LowestCommonAncestor(TreeNode node, List<TreeNode> ints, int qVal, int pVal)
    {
        if (node == null)
        {
            return;
        }

        ints.Add(node);

        if (node.val == qVal)
        {
            _qPathList = new List<TreeNode>(ints);
        }
        else if (node.val == pVal)
        {
            _pPathList = new List<TreeNode>(ints);
        }

        LowestCommonAncestor(node.left, ints, qVal, pVal);
        LowestCommonAncestor(node.right, ints, qVal, pVal);
        ints.RemoveAt(ints.Count - 1);
    }
}