using System.Collections.Generic;

namespace LeetCodeTest.Helper
{
    public static class TreeNodeHelper
    {
        /// <summary>
        /// 依 LeetCode 的 level-order 表示法建樹，例如 [1,2,3,null,5,null,4]。
        /// null 節點不會再往下配置子節點，與 LeetCode 的輸入格式一致。
        /// </summary>
        public static TreeNode Build(int?[] levelOrder)
        {
            if (levelOrder.Length == 0 || levelOrder[0] == null)
                return null;

            var root = new TreeNode(levelOrder[0].Value);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var i = 1;
            while (queue.Count > 0 && i < levelOrder.Length)
            {
                var node = queue.Dequeue();

                if (i < levelOrder.Length)
                {
                    var left = levelOrder[i++];
                    if (left.HasValue)
                    {
                        node.left = new TreeNode(left.Value);
                        queue.Enqueue(node.left);
                    }
                }

                if (i < levelOrder.Length)
                {
                    var right = levelOrder[i++];
                    if (right.HasValue)
                    {
                        node.right = new TreeNode(right.Value);
                        queue.Enqueue(node.right);
                    }
                }
            }

            return root;
        }
    }
}
