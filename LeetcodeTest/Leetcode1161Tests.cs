using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/
// 回傳「該層數值總和最大」的層數 x。root 算第 1 層（1-indexed）。
// 若有多層總和相同，回傳最小的那個層數。
[TestFixture]
public class LeetCode1161Tests
{
    //        1        <- 層1 總和 1
    //       / \
    //      7   0      <- 層2 總和 7
    //     / \
    //    7  -8        <- 層3 總和 -1
    [Test]
    public void example1_second_level_has_the_largest_sum()
    {
        var root = TreeNodeHelper.Build([1, 7, 0, 7, -8, null, null]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(2);
    }

    //   989                      <- 層1  989
    //      \
    //      10250                 <- 層2  10250
    //      /    \
    //  98693   -89388            <- 層3  9305
    //              \
    //             -32127         <- 層4  -32127
    [Test]
    public void example2_largest_sum_is_not_the_widest_level()
    {
        var root = TreeNodeHelper.Build([989, null, 10250, 98693, -89388, null, null, null, -32127]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(2);
    }

    [Test]
    public void single_node_returns_level_one()
    {
        var root = TreeNodeHelper.Build([1]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(1);
    }

    //       -1        <- 層1 總和 -1  (最大值，但是負的)
    //      /  \
    //    -2   -3      <- 層2 總和 -5
    [Test]
    public void all_values_are_negative()
    {
        var root = TreeNodeHelper.Build([-1, -2, -3]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(1);
    }

    //        1        <- 層1 總和 1
    //       / \
    //      2   0      <- 層2 總和 2
    //     /
    //    2            <- 層3 總和 2  (與層2 平手 → 取較小的層數)
    [Test]
    public void tie_returns_the_smallest_level()
    {
        var root = TreeNodeHelper.Build([1, 2, 0, 2, null, null, null]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(2);
    }

    //        0        <- 層1 總和 0
    //       / \
    //     -1   1      <- 層2 總和 0  (與層1 平手 → 取層1)
    [Test]
    public void levels_summing_to_zero_still_tie_on_the_smallest_level()
    {
        var root = TreeNodeHelper.Build([0, -1, 1]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(1);
    }

    //        1        <- 層1 總和 1
    //       / \
    //      2   3      <- 層2 總和 5
    //     /|   |\
    //    4 5   6 7    <- 層3 總和 22
    [Test]
    public void deepest_level_has_the_largest_sum()
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4, 5, 6, 7]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(3);
    }

    //        5        <- 層1 總和 5
    //       / \
    //     -1  -2      <- 層2 總和 -3
    [Test]
    public void root_wins_when_children_are_negative()
    {
        var root = TreeNodeHelper.Build([5, -1, -2]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(1);
    }

    //    1            <- 層1 總和 1
    //     \
    //      2          <- 層2 總和 2
    //       \
    //        3        <- 層3 總和 3
    [Test]
    public void right_skewed_tree_increases_with_depth()
    {
        var root = TreeNodeHelper.Build([1, null, 2, null, 3]);

        var result = new LeetCode1161().MaxLevelSum(root);

        result.Should().Be(3);
    }
}

public class LeetCode1161
{
    public int MaxLevelSum(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        var level = 1;
        var maxSum = int.MinValue;
        var minLevelOfMaxSum = 0;

        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var count = queue.Count;
            var sum = 0;

            for (var i = 0; i < count; i++)
            {
                var treeNode = queue.Dequeue();
                sum += treeNode.val;

                if (treeNode.left != null)
                {
                    queue.Enqueue(treeNode.left);
                }

                if (treeNode.right != null)
                {
                    queue.Enqueue(treeNode.right);
                }
            }

            if (maxSum < sum)
            {
                maxSum = sum;
                minLevelOfMaxSum = level;
            }

            level++;
        }

        return minLevelOfMaxSum;
    }
}