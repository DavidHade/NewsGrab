using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ML_models
{
    public class ArticleModel
    {
        //[LoadColumnName("Headline")]
        public string Headline { get; set; }
        //[LoadColumnName("Article")]
        public string Article { get; set; }
        //[LoadColumnName("Category")]
        public string Category { get; set; }
    }

    public class ArticleModelPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Category;
    }
}
