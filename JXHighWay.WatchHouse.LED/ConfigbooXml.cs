using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.LED
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("config.boo", Namespace = "", IsNullable = false)]
    public partial class ConfigbooXml
    {

        private configbooChannel[] contentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("channel", IsNullable = false)]
        public configbooChannel[] content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannel
    {

        private configbooChannelArea[] areaField;

        private long setSizeField;

        private bool setSizeFieldSpecified;

        private string actionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("area")]
        public configbooChannelArea[] area
        {
            get
            {
                return this.areaField;
            }
            set
            {
                this.areaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long setSize
        {
            get
            {
                return this.setSizeField;
            }
            set
            {
                this.setSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool setSizeSpecified
        {
            get
            {
                return this.setSizeFieldSpecified;
            }
            set
            {
                this.setSizeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelArea
    {

        private configbooChannelAreaRectangle rectangleField;

        private configbooChannelAreaMaterials materialsField;

        private string actionField;

        /// <remarks/>
        public configbooChannelAreaRectangle rectangle
        {
            get
            {
                return this.rectangleField;
            }
            set
            {
                this.rectangleField = value;
            }
        }

        /// <remarks/>
        public configbooChannelAreaMaterials materials
        {
            get
            {
                return this.materialsField;
            }
            set
            {
                this.materialsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaRectangle
    {

        private long xField;

        private long yField;

        private long widthField;

        private long heightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long x
        {
            get
            {
                return this.xField;
            }
            set
            {
                this.xField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long y
        {
            get
            {
                return this.yField;
            }
            set
            {
                this.yField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long width
        {
            get
            {
                return this.widthField;
            }
            set
            {
                this.widthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterials
    {

        private configbooChannelAreaMaterialsVideo[] videoField;

        private configbooChannelAreaMaterialsText textField;

        private configbooChannelAreaMaterialsImage[] imageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("video")]
        public configbooChannelAreaMaterialsVideo[] video
        {
            get
            {
                return this.videoField;
            }
            set
            {
                this.videoField = value;
            }
        }

        /// <remarks/>
        public configbooChannelAreaMaterialsText text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("image")]
        public configbooChannelAreaMaterialsImage[] image
        {
            get
            {
                return this.imageField;
            }
            set
            {
                this.imageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsVideo
    {

        private configbooChannelAreaMaterialsVideoFile fileField;

        private string actionField;

        /// <remarks/>
        public configbooChannelAreaMaterialsVideoFile file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsVideoFile
    {

        private long sizeField;

        private string pathField;

        private string md5Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string md5
        {
            get
            {
                return this.md5Field;
            }
            set
            {
                this.md5Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsText
    {

        private byte singleModeField;

        private byte pageCountField;

        private configbooChannelAreaMaterialsTextContinuousMove continuousMoveField;

        private configbooChannelAreaMaterialsTextFile fileField;

        private string actionField;

        private string guidField;

        /// <remarks/>
        public byte singleMode
        {
            get
            {
                return this.singleModeField;
            }
            set
            {
                this.singleModeField = value;
            }
        }

        /// <remarks/>
        public byte pageCount
        {
            get
            {
                return this.pageCountField;
            }
            set
            {
                this.pageCountField = value;
            }
        }

        /// <remarks/>
        public configbooChannelAreaMaterialsTextContinuousMove continuousMove
        {
            get
            {
                return this.continuousMoveField;
            }
            set
            {
                this.continuousMoveField = value;
            }
        }

        /// <remarks/>
        public configbooChannelAreaMaterialsTextFile file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string guid
        {
            get
            {
                return this.guidField;
            }
            set
            {
                this.guidField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsTextContinuousMove
    {

        private long headCloseToTailField;

        private long speedField;

        private string playTypeField;

        private long byCountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long headCloseToTail
        {
            get
            {
                return this.headCloseToTailField;
            }
            set
            {
                this.headCloseToTailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long speed
        {
            get
            {
                return this.speedField;
            }
            set
            {
                this.speedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string playType
        {
            get
            {
                return this.playTypeField;
            }
            set
            {
                this.playTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long byCount
        {
            get
            {
                return this.byCountField;
            }
            set
            {
                this.byCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsTextFile
    {

        private long sizeField;

        private string pathField;

        private string md5Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string md5
        {
            get
            {
                return this.md5Field;
            }
            set
            {
                this.md5Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsImage
    {

        private configbooChannelAreaMaterialsImageEffect effectField;

        private configbooChannelAreaMaterialsImageFile fileField;

        private string actionField;

        /// <remarks/>
        public configbooChannelAreaMaterialsImageEffect effect
        {
            get
            {
                return this.effectField;
            }
            set
            {
                this.effectField = value;
            }
        }

        /// <remarks/>
        public configbooChannelAreaMaterialsImageFile file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsImageEffect
    {

        private long inField;

        private long outField;

        private long inSpeedField;

        private long outSpeedField;

        private long holdTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long @in
        {
            get
            {
                return this.inField;
            }
            set
            {
                this.inField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long @out
        {
            get
            {
                return this.outField;
            }
            set
            {
                this.outField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long inSpeed
        {
            get
            {
                return this.inSpeedField;
            }
            set
            {
                this.inSpeedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long outSpeed
        {
            get
            {
                return this.outSpeedField;
            }
            set
            {
                this.outSpeedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long holdTime
        {
            get
            {
                return this.holdTimeField;
            }
            set
            {
                this.holdTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configbooChannelAreaMaterialsImageFile
    {

        private long sizeField;

        private string pathField;

        private string md5Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public long size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string md5
        {
            get
            {
                return this.md5Field;
            }
            set
            {
                this.md5Field = value;
            }
        }
    }



}
