using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;

namespace CdnProcessor
{
    public class MediaProvider : Sitecore.Resources.Media.MediaProvider
    {
            public override string GetMediaUrl(MediaItem item)
            {
                Assert.ArgumentNotNull((object)item, "item");
                return this.GetMediaUrl(item, MediaUrlOptions.Empty);
            }

            public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
            {
                Assert.ArgumentNotNull((object)item, "item");
                Assert.ArgumentNotNull((object)options, "options");

                string mediaURL = base.GetMediaUrl(item, options);

                //mediaURL = Sitecore.Web.WebUtil.AddQueryString(mediaURL, new string[] { "revision", ((Item)item).Statistics.Revision });
                //OR
                mediaURL = Sitecore.Web.WebUtil.AddQueryString(mediaURL, new string[] { "modified", ((Item)item).Statistics.Updated.ToString("yyyyMMddHHmmss") });

                return mediaURL;
            }
    }
}
