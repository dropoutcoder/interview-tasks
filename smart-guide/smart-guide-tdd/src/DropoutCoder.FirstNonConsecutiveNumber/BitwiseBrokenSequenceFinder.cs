﻿using DropoutCoder.SmartGuideTdd.FirstNonConsecutiveNumber.Abstraction;

namespace DropoutCoder.SmartGuideTdd.FirstNonConsecutiveNumber
{
    /// <inheritdoc />
    public class BitwiseBrokenSequenceFinder : IBrokenSequenceFinder
    {
        /// <inheritdoc />
        public int? Find(int[] sequence)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (sequence.Length < 2)
            {
                throw new ArgumentException(nameof(sequence), $"Parameter {nameof(sequence)} contains less than allowed minimum items. Minimum numer of allowed items is 2.");
            }

            for (int i = 1; i < sequence.Length; i++)
            {
                if ((sequence[i - 1] + 1 ^ sequence[i]) != 0)
                {
                    return sequence[i];
                }
            }

            return null;
        }
    }
}
