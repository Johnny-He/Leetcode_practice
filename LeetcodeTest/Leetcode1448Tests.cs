using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/count-good-nodes-in-binary-tree/
// 從 root 走到節點 X 的路徑上，若沒有任何節點的值「大於」X，X 就是 good node。
// root 永遠是 good。回傳 good node 的總數。
[TestFixture]
public class LeetCode1448Tests
{
    //        3          <- good (root)
    //       / \
    //      1   4        <- 1 不是 (1 < 3)，4 是 good
    //     /   / \
    //    3   1   5      <- 3 是 good (路徑 3,1,3)，1 不是，5 是 good
    [Test]
    public void example1()
    {
        var root = TreeNodeHelper.Build([3, 1, 4, 3, null, 1, 5]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(4);
    }

    //        3          <- good
    //       /
    //      3            <- good (3 >= 3，相等也算)
    //     / \
    //    4   2          <- 4 是 good，2 不是
    [Test]
    public void example2()
    {
        var root = TreeNodeHelper.Build([3, 3, null, 4, 2]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(3);
    }

    [Test]
    public void example3_single_node_is_always_good()
    {
        var root = TreeNodeHelper.Build([1]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(1);
    }

    [Test]
    public void single_negative_node_is_still_good()
    {
        var root = TreeNodeHelper.Build([-1]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(1);
    }

    //        2          <- good
    //       / \
    //      2   2        <- 兩個都 good (相等不算「大於」)
    [Test]
    public void equal_values_count_as_good()
    {
        var root = TreeNodeHelper.Build([2, 2, 2]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(3);
    }

    //    5              <- good
    //     \
    //      4            <- 不是
    //       \
    //        3          <- 不是
    [Test]
    public void strictly_decreasing_chain_only_root_is_good()
    {
        var root = TreeNodeHelper.Build([5, null, 4, null, 3]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(1);
    }

    //    1              <- good
    //     \
    //      2            <- good
    //       \
    //        3          <- good
    [Test]
    public void strictly_increasing_chain_all_are_good()
    {
        var root = TreeNodeHelper.Build([1, null, 2, null, 3]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(3);
    }

    //       -5          <- good
    //       /  \
    //     -3   -10      <- -3 是 good (-3 > -5)，-10 不是
    [Test]
    public void negative_values()
    {
        var root = TreeNodeHelper.Build([-5, -3, -10]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(2);
    }

    //        2          <- good
    //       /
    //      4            <- good
    //     / \
    //    1   3          <- 都不是 (路徑上的 4 擋住了整個子樹)
    [Test]
    public void a_large_ancestor_blocks_its_whole_subtree()
    {
        var root = TreeNodeHelper.Build([2, 4, null, 1, 3]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(2);
    }

    //        1          <- good
    //       / \
    //      5   2        <- 都 good
    //           \
    //            3      <- good (路徑 1,2,3 的最大值是 2，跟另一條分支的 5 無關)
    [Test]
    public void path_max_is_per_branch_not_global()
    {
        var root = TreeNodeHelper.Build([1, 5, 2, null, null, null, 3]);

        var result = new LeetCode1448().GoodNodes(root);

        result.Should().Be(4);
    }
}

public class LeetCode1448
{
    public int GoodNodes(TreeNode root)
    {
        return SumGoodNodes(root, int.MinValue);
    }

    private int SumGoodNodes(TreeNode node, int max)
    {
        if (node == null)
        {
            return 0;
        }

        var count = 0;
        if (node.val >= max)
        {
            count++;
            max = node.val;
        }

        return count + SumGoodNodes(node.left, max) + SumGoodNodes(node.right, max);
    }
}