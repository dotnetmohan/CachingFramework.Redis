using System.Collections.Generic;

namespace CachingFramework.Redis.Contracts.RedisObjects
{
    /// <summary>
    /// Managed ICollection using a Redis Sorted Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICachedSortedSet<T> : IRedisObject, ICollection<T> 
    {
        /// <summary>
        /// Adds the specified member with the specified score to the sorted set stored at key. 
        /// If key does not exist, a new sorted set with the specified member as sole member is created, like if the sorted set was empty. 
        /// </summary>
        /// <param name="member">The sorted member to add.</param>
        void Add(SortedMember<T> member);
        /// <summary>
        /// Adds the specified member with the specified score to the sorted set stored at key. 
        /// If key does not exist, a new sorted set with the specified member as sole member is created, like if the sorted set was empty. 
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="score">The item score.</param>
        void Add(double score, T item);
        /// <summary>
        /// Adds all the specified members with the specified scores to the sorted set stored at key. 
        /// If key does not exist, a new sorted set with the specified members as sole members is created, like if the sorted set was empty. 
        /// </summary>
        /// <param name="members">The members to add.</param>
        void AddRange(IEnumerable<SortedMember<T>> members);
        /// <summary>
        /// Returns the number of elements in the sorted set at key with a score between min and max.
        /// </summary>
        /// <param name="min">The minimum score to consider (inclusive).</param>
        /// <param name="max">The maximum score to consider (inclusive).</param>
        long CountByScore(double min, double max);
        /// <summary>
        /// Returns all the elements in the sorted set at key with a score between min and max (inclusive). 
        /// </summary>
        /// <param name="min">The minimum score to consider.</param>
        /// <param name="max">The maximum score to consider.</param>
        /// <param name="descending">if set to <c>true</c> the elements are considered to be ordered from high to low scores.</param>
        /// <param name="skip">The skip number for result pagination.</param>
        /// <param name="take">The take number for result pagination.</param>
        IEnumerable<SortedMember<T>> GetRangeByScore(double min = double.NegativeInfinity,
            double max = double.PositiveInfinity, bool descending = false, long skip = 0, long take = -1);
        /// <summary>
        /// Returns the specified range of elements in the sorted set stored at key. The elements are considered to be ordered from the lowest to the highest score by default.
        /// </summary>
        /// <param name="start">The start zero-based index (can be negative number indicating offset from the end of the sorted set).</param>
        /// <param name="stop">The stop zero-based index (can be negative number indicating offset from the end of the sorted set).</param>
        /// <param name="descending">if set to <c>true</c> the elements are considered to be ordered from high to low scores.</param>
        IEnumerable<SortedMember<T>> GetRangeByRank(long start = 0, long stop = -1, bool descending = false);
        /// <summary>
        /// Removes all elements in the sorted set with a score between min and max (inclusive).
        /// </summary>
        /// <param name="min">The minimum score to consider.</param>
        /// <param name="max">The maximum score to consider.</param>
        void RemoveRangeByScore(double min, double max);
        /// <summary>
        /// Removes all elements in the sorted set stored with rank between start and stop. 
        /// Both start and stop are zero-based indexes with 0 being the element with the lowest score. 
        /// These indexes can be negative numbers, where they indicate offsets starting at the element with the highest score. 
        /// </summary>
        /// <param name="start">The start zero-based index (can be negative number indicating offset from the end of the sorted set).</param>
        /// <param name="stop">The stop zero-based index (can be negative number indicating offset from the end of the sorted set).</param>
        void RemoveRangeByRank(long start, long stop);
        /// <summary>
        /// Increments the score of member in the sorted by the given value. 
        /// If member does not exist in the sorted set, it is added with increment as its score (as if its previous score was 0.0). 
        /// If key does not exist, a new sorted set with the specified member as its sole member is created.
        /// </summary>
        /// <param name="item">The item to increment its score.</param>
        /// <param name="value">The increment value.</param>
        /// <returns>The new score of the member</returns>
        double IncrementScore(T item, double value);
        /// <summary>
        /// Returns the rank of member in the sorted set, with the scores ordered from low to high by default. 
        /// The rank (or index) is zero-based.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="descending">if set to <c>true</c> the elements are considered to be ordered from high to low scores.</param>
        /// <returns>The rank of the item in the sorted set, or NULL when the key or the member does not exists</returns>
        long? RankOf(T item, bool descending = false);
        /// <summary>
        /// Returns the score of member in the sorted set at key.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The score of the item in the sorted set, or NULL when the key or the member does not exists</returns>
        double? ScoreOf(T item);
        /// <summary>
        /// Returns the number of elements in the sorted set.
        /// </summary>
        new long Count { get; }
    }
}