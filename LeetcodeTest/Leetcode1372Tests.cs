using System;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/
// 任選一個起點和一個方向，走到該方向的子節點後「必須換方向」，如此交替下去。
// ZigZag 長度 = 經過的「邊」數（= 節點數 - 1）。單一節點的長度是 0。
[TestFixture]
public class LeetCode1372Tests
{
    [Test]
    public void example1()
    {
        var root = TreeNodeHelper.Build(
            [1, null, 1, 1, 1, null, null, 1, 1, null, 1, null, null, null, 1, null, 1]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(3);
    }

    [Test]
    public void example2()
    {
        var root = TreeNodeHelper.Build([1, 1, 1, null, 1, null, null, 1, 1, null, 1]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(4);
    }

    [Test]
    public void example3_single_node_has_length_zero()
    {
        var root = TreeNodeHelper.Build([1]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(0);
    }

    //    1
    //   /
    //  2                 一條邊就是長度 1
    [Test]
    public void two_nodes_have_length_one()
    {
        var root = TreeNodeHelper.Build([1, 2]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(1);
    }

    //    1
    //   /
    //  2                 一路向左，無法交替
    // /                  最長只能走一條邊
    //3
    [Test]
    public void straight_left_chain_cannot_zigzag()
    {
        var root = TreeNodeHelper.Build([1, 2, null, 3]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(1);
    }

    //  1
    //   \
    //    2               一路向右，同理
    //     \
    //      3
    [Test]
    public void straight_right_chain_cannot_zigzag()
    {
        var root = TreeNodeHelper.Build([1, null, 2, null, 3]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(1);
    }

    //      1
    //     /
    //    2              左 → 右 → 左，三條邊
    //     \
    //      3
    //     /
    //    4
    [Test]
    public void perfect_zigzag_from_root_going_left_first()
    {
        var root = TreeNodeHelper.Build([1, 2, null, null, 3, 4]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(3);
    }

    //  1
    //   \
    //    2              右 → 左 → 右，三條邊
    //   /
    //  3
    //   \
    //    4
    [Test]
    public void perfect_zigzag_from_root_going_right_first()
    {
        var root = TreeNodeHelper.Build([1, null, 2, 3, null, null, 4]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(3);
    }

    //      1
    //     /
    //    2              最長的 zigzag 是 2→3→4→5（左右左），不包含 root
    //   /
    //  3
    //   \
    //    4
    //   /
    //  5
    [Test]
    public void longest_zigzag_does_not_start_at_root()
    {
        var root = TreeNodeHelper.Build([1, 2, null, 3, null, null, 4, 5]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(3);
    }

    //        1
    //       / \
    //      2   3        完整二元樹只有 3 層，最長 zigzag 是兩條邊
    //     / \ / \
    //    4  5 6  7
    [Test]
    public void perfect_binary_tree_is_limited_by_its_height()
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4, 5, 6, 7]);

        var result = new LeetCode1372().LongestZigZag(root);

        result.Should().Be(2);
    }
}

public class LeetCode1372
{
    private int _maxNodeCount;

    public int LongestZigZag(TreeNode root)
    {
        LongestZigZag(root, 0, true);
        LongestZigZag(root, 0, false);
        return _maxNodeCount - 1;
    }

    private void LongestZigZag(TreeNode node, int nodeCount, bool shouldGoLeft)
    {
        if (node == null)
        {
            return;
        }

        nodeCount++;
        _maxNodeCount = Math.Max(_maxNodeCount, nodeCount);
        if (shouldGoLeft)
        {
            LongestZigZag(node.left, nodeCount, false);
            LongestZigZag(node.right, 1, true);
        }
        else
        {
            LongestZigZag(node.right, nodeCount, true);
            LongestZigZag(node.left, 1, false);
        }
    }
}