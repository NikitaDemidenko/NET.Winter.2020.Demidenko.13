using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeTask
{
    /// <summary>
    /// Binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private readonly IComparer<T> comparer;
        private Node<T> root;
        private EnumerationType enumerationType;

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class that uses a default comparer.</summary>
        public BinarySearchTree()
        {
            this.comparer = Comparer<T>.Default;
            this.enumerationType = EnumerationType.PreOrder;
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.</summary>
        /// <param name="enumerationType">Type of the enumeration.</param>
        public BinarySearchTree(EnumerationType enumerationType)
            : this()
        {
            this.enumerationType = enumerationType;
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class that uses a specified comparer.</summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null.</exception>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            this.enumerationType = EnumerationType.PreOrder;
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.</summary>
        /// <param name="comparer">The comparer.</param>
        /// <param name="enumerationType">Type of the enumeration.</param>
        public BinarySearchTree(IComparer<T> comparer, EnumerationType enumerationType)
            : this(comparer)
        {
            this.enumerationType = enumerationType;
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class that contains elements copied from a specified enumerable collection.</summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null.</exception>
        public BinarySearchTree(IEnumerable<T> collection)
            : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var item in collection)
            {
                this.AddItem(item);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.</summary>
        /// <param name="collection">The collection.</param>
        /// <param name="enumerationType">Type of the enumeration.</param>
        public BinarySearchTree(IEnumerable<T> collection, EnumerationType enumerationType)
            : this(collection)
        {
            this.enumerationType = enumerationType;
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class that contains elements copied from a specified enumerable collection and that uses a specified comparer.</summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">Thrown when collection is null.</exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
            : this(comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var item in collection)
            {
                this.AddItem(item);
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.</summary>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="enumerationType">Type of the enumeration.</param>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer, EnumerationType enumerationType)
            : this(collection, comparer)
        {
            this.enumerationType = enumerationType;
        }

        /// <summary>Adds the item into the tree.</summary>
        /// <param name="item">The item.</param>
        public void AddItem(T item)
        {
            var newNode = new Node<T>(item);
            if (this.root == null)
            {
                this.root = newNode;
                return;
            }

            var currentNode = this.root;
            while (currentNode != null)
            {
                if (this.comparer.Compare(item, currentNode.Data) <= 0)
                {
                    if (!currentNode.HasLeftChild())
                    {
                        currentNode.Left = newNode;
                        currentNode = null;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (!currentNode.HasRightChild())
                    {
                        currentNode.Right = newNode;
                        currentNode = null;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }

        /// <summary>Determines whether this tree contains the item.</summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if tree contains the item; otherwise, <c>false</c>.</returns>
        public bool Contains(T item)
        {
            var currentNode = this.root;
            while (currentNode != null)
            {
                if (this.comparer.Compare(item, currentNode.Data) == 0)
                {
                    return true;
                }

                currentNode = this.comparer.Compare(item, currentNode.Data) < 0 ? currentNode.Left : currentNode.Right;
            }

            return false;
        }

        /// <summary>Preorder traversal of tree.</summary>
        /// <returns>Returns tree items using preorder traversal.</returns>
        public IEnumerable<T> PreorderTraversal()
        {
            return PreorderTraversal(this.root);

            static IEnumerable<T> PreorderTraversal(Node<T> node)
            {
                if (node == null)
                {
                    yield break;
                }

                yield return node.Data;

                if (node.HasLeftChild())
                {
                    foreach (var item in PreorderTraversal(node.Left))
                    {
                        yield return item;
                    }
                }

                if (node.HasRightChild())
                {
                    foreach (var item in PreorderTraversal(node.Right))
                    {
                        yield return item;
                    }
                }
            }
        }

        /// <summary>Postorder traversal of tree.</summary>
        /// <returns>Returns tree items using postorder traversal.</returns>
        public IEnumerable<T> PostorderTraversal()
        {
            return PostorderTraversal(this.root);

            static IEnumerable<T> PostorderTraversal(Node<T> node)
            {
                if (node == null)
                {
                    yield break;
                }

                if (node.HasLeftChild())
                {
                    foreach (var item in PostorderTraversal(node.Left))
                    {
                        yield return item;
                    }
                }

                if (node.HasRightChild())
                {
                    foreach (var item in PostorderTraversal(node.Right))
                    {
                        yield return item;
                    }
                }

                yield return node.Data;
            }
        }

        /// <summary>Inorder traversal of tree.</summary>
        /// <returns>Returns tree items using inorder traversal.</returns>
        public IEnumerable<T> InorderTraversal()
        {
            return InorderTraversal(this.root);

            static IEnumerable<T> InorderTraversal(Node<T> node)
            {
                if (node == null)
                {
                    yield break;
                }

                if (node.HasLeftChild())
                {
                    foreach (var item in InorderTraversal(node.Left))
                    {
                        yield return item;
                    }
                }

                yield return node.Data;

                if (node.HasRightChild())
                {
                    foreach (var item in InorderTraversal(node.Right))
                    {
                        yield return item;
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            switch (this.enumerationType)
            {
                case EnumerationType.PostOrder:
                    foreach (var item in this.PostorderTraversal())
                    {
                        yield return item;
                    }

                    break;
                case EnumerationType.PreOrder:
                    foreach (var item in this.PreorderTraversal())
                    {
                        yield return item;
                    }

                    break;
                case EnumerationType.InOrder:
                    foreach (var item in this.InorderTraversal())
                    {
                        yield return item;
                    }

                    break;
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
