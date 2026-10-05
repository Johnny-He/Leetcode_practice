using System;
using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/maximum-depth-of-binary-tree/
// 回傳二元樹的最大深度：從 root 走到「最遠的葉子」這條路徑上的節點數。
// 節點數 0 ~ 10^4，-100 <= val <= 100。
[TestFixture]
public class LeetCode104Tests
{
    //        3          <- depth 1
    //       / \
    //      9   20       <- depth 2
    //         /  \
    //        15   7     <- depth 3
    [Test]
    public void example1()
    {
        var root = TreeNodeHelper.Build([3, 9, 20, null, null, 15, 7]);
        ;

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(3);
    }

    //    1
    //     \
    //      2
    [Test]
    public void example2()
    {
        var root = TreeNodeHelper.Build([1, null, 2]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(2);
    }

    [Test]
    public void empty_tree_has_depth_zero()
    {
        var root = TreeNodeHelper.Build([]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(0);
    }

    [Test]
    public void single_node_has_depth_one()
    {
        var root = TreeNodeHelper.Build([0]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(1);
    }

    //        1
    //       /
    //      2
    //     /
    //    3
    //   /
    //  4
    [Test]
    public void left_skewed_chain()
    {
        var root = TreeNodeHelper.Build([1, 2, null, 3, null, 4]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(4);
    }

    //        1
    //       / \
    //      2   3
    //     / \ / \
    //    4  5 6  7
    [Test]
    public void perfect_tree()
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4, 5, 6, 7]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(3);
    }

    //        1
    //       / \
    //      2   3         <- 左邊比較「寬」(節點多)
    //     / \   \
    //    4   5   6       <- 但最深的在右邊
    //             \
    //              7
    //               \
    //                8
    [Test]
    public void deepest_branch_is_not_the_widest_one()
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4, 5, null, 6, null, null, null, null, null, 7, null, 8]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(5);
    }

    //        1
    //       / \
    //      2   3
    //       \
    //        4
    //       /
    //      5
    [Test]
    public void zigzag_path_on_the_left()
    {
        var root = TreeNodeHelper.Build([1, 2, 3, null, 4, null, null, 5]);

        var result = new LeetCode104().MaxDepthByDfs(root);

        result.Should().Be(4);
    }


    // NUnit worker thread 在 macOS 預設只有 512KB stack，LeetCode judge 大約 8MB。
    // 10^4 層遞迴在 judge 上會過，這裡用 8MB 的 thread 跑，才不會讓整個 test host 當掉。
    private static int RunWithLeetCodeStackSize(Func<int> action)
    {
        var result = 0;
        var thread = new Thread(() => result = action(), 8 * 1024 * 1024);
        thread.Start();
        thread.Join();
        return result;
    }
}

public class LeetCode104
{
    public int MaxDepthByDfs(TreeNode root)
    {
        return MaxDepthByBfs(root);
        // return MaxDepthByDfs(root, 0);
    }

    public int MaxDepthByBfs(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var level = 0;
        while (queue.Count > 0)
        {
            level++;
            var count = queue.Count;
            for (var i = 0; i < count; i++)
            {
                var treeNode = queue.Dequeue();
                if (treeNode.left != null)
                {
                    queue.Enqueue(treeNode.left);
                }
                if (treeNode.right != null)
                {
                    queue.Enqueue(treeNode.right);
                }
            }
        }

        return level;
    }


    private int MaxDepthByDfs(TreeNode node, int level)
    {
        if (node == null)
        {
            return 0;
        }

        level++;
        var leftLevel = MaxDepthByDfs(node.left, level);
        var rightLevel = MaxDepthByDfs(node.right, level);
        var max = Math.Max(leftLevel, rightLevel);
        return Math.Max(max, level);
    }
}