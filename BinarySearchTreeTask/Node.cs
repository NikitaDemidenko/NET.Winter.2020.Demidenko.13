using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeTask
{
    /// <summary>Node of the tree.</summary>
    /// <typeparam name="T">Type of node's data.</typeparam>
    public class Node<T>
    {
        /// <summary>Initializes a new instance of the <see cref="Node{T}"/> class.</summary>
        /// <param name="data">The data.</param>
        /// <exception cref="ArgumentNullException">Thrown when data is null.</exception>
        public Node(T data)
        {
            this.Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>Gets or sets the data.</summary>
        /// <value>The data.</value>
        public T Data { get; set; }

        /// <summary>Gets or sets the left node.</summary>
        /// <value>The left node.</value>
        public Node<T> Left { get; set; }

        /// <summary>Gets or sets the right node.</summary>
        /// <value>The right node.</value>
        public Node<T> Right { get; set; }

        /// <summary>Determines whether this node has left child.</summary>
        /// <returns>
        ///   <c>true</c> if this node has left child; otherwise, <c>false</c>.</returns>
        public bool HasLeftChild() => this.Left != null;

        /// <summary>Determines whether this node has right child.</summary>
        /// <returns>
        ///   <c>true</c> if this node has right child; otherwise, <c>false</c>.</returns>
        public bool HasRightChild() => this.Right != null;
    }
}
