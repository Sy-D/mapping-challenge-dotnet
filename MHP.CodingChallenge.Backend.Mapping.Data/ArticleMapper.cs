using System;
using System.Collections.Generic;
using System.Linq;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DB.Blocks;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO.Blocks;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleMapper
    {
        /// <summary>
        /// Maps the specified article to a client facing dto.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns>The dto.</returns>
        public ArticleDto Map(Article article)
        {
            return new ArticleDto
            {
                Author = article.Author,
                Description = article.Description,
                Id = article.Id,
                Title = article.Title,
                Blocks = article.Blocks.Select(b => Map(b)).ToList()
            };
        }


        /// <summary>
        /// Maps the specified article dto to a database entity.
        /// </summary>
        /// <param name="articleDto">The article dto.</param>
        /// <returns>The db entity.</returns>
        public Article Map(ArticleDto articleDto)
        {
            // Nicht Teil dieser Challenge.
            return new Article();
        }



        private ArticleBlock Map(ArticleBlockDto block)
        {
            // Nicht Teil dieser Challenge.
            return new ArticleBlock();
        }


        private ArticleBlockDto Map(ArticleBlock block)
        {
            ArticleBlockDto blockDto = block switch
            {
                GalleryBlock b => new GalleryBlockDto() { Images = Map(b.Images), SortIndex = b.SortIndex },
                ImageBlock b => new ImageBlockDto { Image = Map(b.Image), SortIndex = b.SortIndex },
                TextBlock b => new TextBlockDto { Text = b.Text, SortIndex = b.SortIndex },
                VideoBlock b => new VideoBlockDto { Url = b.Url, Type = b.Type, SortIndex = b.SortIndex },
                _ => throw new ArticleMappingException("Block type does not exist")
            };

            return blockDto;
        }

        private ImageDto Map(Image image)
        {
            return new ImageDto();
        }

        private List<ImageDto> Map(IEnumerable<Image> images)
        {
            return images.Select(img => new ImageDto()).ToList();
        }
    }
}
