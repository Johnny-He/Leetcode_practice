using System;
using System.Collections.Generic;
using FluentAssertions;
using LeetCodeTest.Helper;
using NUnit.Framework;

namespace LeetCodeTest;

// https://leetcode.com/problems/binary-tree-right-side-view/
// 站在樹的右邊往左看，由上而下回傳每一層「最右邊」看得到的節點值。
//
// 同一組測試會跑兩種實作：
//   two_queue_recursive - 雙 queue 分層 + 遞迴
//   standard_bfs        - 單 queue + levelSize 凍結（最常見的 BFS 模板）
[TestFixture]
public class LeetCode199Test
{
    private static IEnumerable<TestCaseData> Implementations()
    {
        yield return new TestCaseData((Func<TreeNode, IList<int>>)(root => new LeetCode199().RightSideView(root)))
            .SetName("{m}_two_queue_recursive");

        yield return new TestCaseData((Func<TreeNode, IList<int>>)(root => new LeetCode199().RightSideViewRenamed(root)))
            .SetName("{m}_two_queue_renamed");

        yield return new TestCaseData((Func<TreeNode, IList<int>>)(root => new LeetCode199().RightSideViewBfs(root)))
            .SetName("{m}_standard_bfs");
    }

    //       1          <- 1
    //      / \
    //     2   3        <- 3
    //      \    \
    //       5    4     <- 4
    [TestCaseSource(nameof(Implementations))]
    public void example1_each_level_reports_its_rightmost_node(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1, 2, 3, null, 5, null, 4]);

        var result = rightSideView(root);

        result.Should().Equal(1, 3, 4);
    }

    //     1            <- 1
    //      \
    //       3          <- 3
    [TestCaseSource(nameof(Implementations))]
    public void example2_only_right_children(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1, null, 3]);

        var result = rightSideView(root);

        result.Should().Equal(1, 3);
    }

    [TestCaseSource(nameof(Implementations))]
    public void example3_empty_tree_returns_empty(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([]);

        var result = rightSideView(root);

        result.Should().BeEmpty();
    }

    [TestCaseSource(nameof(Implementations))]
    public void single_node(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1]);

        var result = rightSideView(root);

        result.Should().Equal(1);
    }

    //       1          <- 1
    //      /
    //     2            <- 2
    //    /
    //   3              <- 3
    [TestCaseSource(nameof(Implementations))]
    public void only_left_children_are_still_visible(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1, 2, null, 3]);

        var result = rightSideView(root);

        result.Should().Equal(1, 2, 3);
    }

    //       1          <- 1
    //      / \
    //     2   3        <- 3
    //    /
    //   4              <- 4   (右子樹已經到底，這層只剩左邊的節點)
    [TestCaseSource(nameof(Implementations))]
    public void left_subtree_is_deeper_than_right_subtree(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4]);

        var result = rightSideView(root);

        result.Should().Equal(1, 3, 4);
    }

    //       1          <- 1
    //      / \
    //     2   3        <- 3
    //    /
    //   4              <- 4
    //  /
    // 5                <- 5   (最深的節點是一路往左)
    [TestCaseSource(nameof(Implementations))]
    public void deepest_node_is_reached_through_left_children(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4, null, null, null, 5]);

        var result = rightSideView(root);

        result.Should().Equal(1, 3, 4, 5);
    }

    //         1        <- 1
    //        / \
    //       2   3      <- 3
    //      / \   \
    //     4   5   6    <- 6
    //        /
    //       7          <- 7
    [TestCaseSource(nameof(Implementations))]
    public void mixed_tree_picks_rightmost_of_every_level(Func<TreeNode, IList<int>> rightSideView)
    {
        var root = TreeNodeHelper.Build([1, 2, 3, 4, 5, null, 6, null, null, 7]);

        var result = rightSideView(root);

        result.Should().Equal(1, 3, 6, 7);
    }
}

public class LeetCode199
{
    // ── 版本 1：你原本寫的雙 queue 遞迴版（原封不動保留）──────────────
    public IList<int> RightSideView(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>();
        }
        var treeNodes = new Queue<TreeNode>();
        treeNodes.Enqueue(root);
        var result = new List<int>();
        FindRightNodeValue(treeNodes, result);
        return result;

    }

    private static void FindRightNodeValue(Queue<TreeNode> treeNodes, List<int> ints)
    {
        if (treeNodes.Count == 0)
        {
            return;
        }
        
        var nodes = new Queue<TreeNode>();
        var treeNode = new TreeNode();
        while (treeNodes.Count > 0)
        {
            treeNode = treeNodes.Dequeue();
            if (treeNode.left != null)
            {
                nodes.Enqueue(treeNode.left);
            }

            if (treeNode.right != null)
            {
                nodes.Enqueue(treeNode.right);
            }
        }

        ints.Add(treeNode.val);
        FindRightNodeValue(nodes, ints);
    }

    // ── 版本 2：同樣的演算法，只換命名與初值 + 加上註解 ──────────────
    public IList<int> RightSideViewRenamed(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>();
        }

        // 用一個 queue 裝「當前這一層」的節點，遞迴時把「下一層」傳下去。
        // 兩個 queue 天然把層與層隔開，所以不需要像標準 BFS 那樣另外記錄每層的節點數。
        var currentLevel = new Queue<TreeNode>();
        currentLevel.Enqueue(root);

        var result = new List<int>();
        CollectRightmostOfEachLevel(currentLevel, result);
        return result;
    }

    private static void CollectRightmostOfEachLevel(Queue<TreeNode> currentLevel, List<int> result)
    {
        // 上一層沒有產生任何子節點 → 整棵樹走完了
        if (currentLevel.Count == 0)
        {
            return;
        }

        var nextLevel = new Queue<TreeNode>();

        // 初值刻意用 null 而不是 new TreeNode()：
        // 上面的 guard 保證 while 至少跑一次，所以這裡一定會被賦值。
        // 萬一日後有人把 guard 拿掉，null 會立刻拋 NullReferenceException；
        // 用 dummy 物件則會靜默地把 val = 0 加進答案，變成更難查的 bug。
        TreeNode rightmost = null;

        // 迴圈中 rightmost 的語意是「這一層目前為止看過的最右節點」，
        // 因為是由左往右依序 dequeue，迴圈結束時它就是這一層真正的最右邊。
        while (currentLevel.Count > 0)
        {
            rightmost = currentLevel.Dequeue();

            // 先左後右入隊，下一層才會維持由左到右的順序
            if (rightmost.left != null)
            {
                nextLevel.Enqueue(rightmost.left);
            }

            if (rightmost.right != null)
            {
                nextLevel.Enqueue(rightmost.right);
            }
        }

        result.Add(rightmost.val);

        CollectRightmostOfEachLevel(nextLevel, result);
    }

    // ── 版本 3：標準 BFS 模板，單一 queue + 每輪凍結當層節點數 ──────────
    // 這是樹/圖分層走訪最通用的寫法，102 / 103 / 104 / 111 / 994 都是同一個骨架，
    // 只需要替換 for 迴圈裡「對這一層要做什麼」的那幾行。
    public IList<int> RightSideViewBfs(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            // 必須先把當層節點數凍結起來：for 迴圈執行中會不斷 enqueue 子節點，
            // queue.Count 一直在變，直接拿來當界線就分不出層次了。
            var levelSize = queue.Count;

            for (var i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();

                // 依序 dequeue，第 levelSize-1 個就是這一層最右邊的節點
                if (i == levelSize - 1)
                {
                    result.Add(node.val);
                }

                // 先左後右，下一層才會維持由左到右的順序
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            // for 跑完的瞬間，queue 裡剛好是完整的下一層 → 下一輪 while 直接接手
        }

        return result;
    }
}
