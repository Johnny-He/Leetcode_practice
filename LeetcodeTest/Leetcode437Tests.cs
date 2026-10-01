using System;
using System.Collections.Generic;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/path-sum-iii/
// 計算總和等於 targetSum 的路徑數量。
// 路徑必須「由上往下」（parent → child），但不必從 root 開始、也不必在葉節點結束。
[TestFixture]
public class LeetCode437Tests
{
    //          10
    //         /  \
    //        5   -3
    //       / \    \
    //      3   2   11
    //     / \   \
    //    3  -2   1
    //
    // target = 8 的三條路徑：5→3、5→2→1、-3→11
    [Test]
    public void example1()
    {
        var root = TreeNodeHelper.Build([10, 5, -3, 3, 2, null, 11, 3, -2, null, 1]);

        var result = new LeetCode437().PathSum(root, 8);

        result.Should().Be(3);
    }

    //          5
    //         / \
    //        4   8
    //       /   / \
    //      11  13  4
    //     / \     / \
    //    7   2   5   1
    [Test]
    public void example2()
    {
        var root = TreeNodeHelper.Build([5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1]);

        var result = new LeetCode437().PathSum(root, 22);

        result.Should().Be(3);
    }

    [Test]
    public void empty_tree_has_no_path()
    {
        var root = TreeNodeHelper.Build([]);

        var result = new LeetCode437().PathSum(root, 0);

        result.Should().Be(0);
    }

    [Test]
    public void single_node_matching_target()
    {
        var root = TreeNodeHelper.Build([1]);

        var result = new LeetCode437().PathSum(root, 1);

        result.Should().Be(1);
    }

    [Test]
    public void single_node_not_matching_target()
    {
        var root = TreeNodeHelper.Build([1]);

        var result = new LeetCode437().PathSum(root, 2);

        result.Should().Be(0);
    }

    //        0
    //       / \
    //      0   0
    //
    // 五條：[0]×3、[0→0]×2
    [Test]
    public void zero_values_make_every_subpath_count()
    {
        var root = TreeNodeHelper.Build([0, 0, 0]);

        var result = new LeetCode437().PathSum(root, 0);

        result.Should().Be(5);
    }

    //        1
    //       / \
    //     -2  -3
    //
    // target = -2 的兩條：[-2]、[1→-3]
    [Test]
    public void negative_target()
    {
        var root = TreeNodeHelper.Build([1, -2, -3]);

        var result = new LeetCode437().PathSum(root, -2);

        result.Should().Be(2);
    }

    //        1
    //       / \
    //      2   3
    //
    // 2→1→3 = 6 是「V 字形」路徑，不合法（路徑只能往下走）
    // 合法路徑只有 1、2、3、1→2、1→3 → 沒有任何一條等於 6
    [Test]
    public void path_must_go_downward_only()
    {
        var root = TreeNodeHelper.Build([1, 2, 3]);

        var result = new LeetCode437().PathSum(root, 6);

        result.Should().Be(0);
    }

    //   1000000000
    //      /
    //  -1000000000
    //
    // 大正數與大負數互相抵銷，只有整條路徑等於 0
    [Test]
    public void large_values_cancel_out()
    {
        var root = TreeNodeHelper.Build([1000000000, -1000000000]);

        var result = new LeetCode437().PathSum(root, 0);

        result.Should().Be(1);
    }

    // 一條 5 個節點的右斜鏈，總和剛好是 2^32 = 4294967296。
    // 全部是正數，所以沒有任何一段的總和是 0 → 答案是 0。
    // 但若用 int 累加，整條路徑會溢位並「繞回」0，誤判成 1。
    [Test]
    public void running_sum_must_not_overflow_int()
    {
        var root = TreeNodeHelper.Build(
            [858993459, null, 858993459, null, 858993459, null, 858993459, null, 858993460]);

        var result = new LeetCode437().PathSum(root, 0);

        result.Should().Be(0);
    }
}

public class LeetCode437
{
    public int PathSum(TreeNode root, int targetSum)
    {
        return PathSum(root, targetSum, []);
    }

    private static int PathSum(TreeNode root, int targetSum, List<long> pathValues)
    {
        if (root == null)
        {
            return 0;
        }

        pathValues.Add(root.val);
        long sum = 0;

        var hitTargetSumCount = 0;
        for (var i = pathValues.Count - 1; i >= 0; i--)
        {
            sum += pathValues[i];
            if (sum == targetSum)
            {
                hitTargetSumCount++;
            }
        }

        hitTargetSumCount += PathSum(root.left, targetSum, pathValues);
        hitTargetSumCount += PathSum(root.right, targetSum, pathValues);

        pathValues.RemoveAt(pathValues.Count - 1);

        return hitTargetSumCount;
    }
}