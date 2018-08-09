﻿using System;
using NBitcoin;

namespace Stratis.Bitcoin.Utilities
{
    /// <summary>Pair of block hash and block height.</summary>
    public class HashHeightPair : IBitcoinSerializable
    {
        private uint256 hash;

        private int height;

        public uint256 Hash => this.hash;

        public int Height => this.height;

        public HashHeightPair()
        {
        }

        public HashHeightPair(uint256 hash, int height)
        {
            Guard.NotNull(hash, nameof(hash));

            this.hash = hash;
            this.height = height;
        }

        public static HashHeightPair Load(byte[] bytes)
        {
            Guard.NotNull(bytes, nameof(bytes));

            var pair = new HashHeightPair();

            pair.ReadWrite(bytes);

            return pair;
        }

        /// <inheritdoc />
        public void ReadWrite(BitcoinStream stream)
        {
            stream.ReadWrite(ref this.hash);
            stream.ReadWrite(ref this.height);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.height + "-" + this.hash;
        }
    }
}