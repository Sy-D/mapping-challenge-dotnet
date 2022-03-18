using System;
namespace MHP.CodingChallenge.Backend.Mapping.Data.DTO
{
    public class ArticleBlockDto : IComparable<ArticleBlockDto>
    {
        public int SortIndex { get; set; }

        public int CompareTo(ArticleBlockDto obj)
        {
            return SortIndex - obj.SortIndex;
        }
    }
}
