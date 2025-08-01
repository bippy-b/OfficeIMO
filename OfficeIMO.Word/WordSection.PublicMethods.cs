using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace OfficeIMO.Word {
    /// <summary>
    /// Adds public operations for working with sections.
    /// </summary>
    public partial class WordSection {
        /// <summary>
        /// Updates the margins for this section.
        /// </summary>
        /// <param name="pageMargins">Margin values to apply.</param>
        /// <returns>The current section.</returns>
        public WordSection SetMargins(WordMargin pageMargins) {
            return WordMargins.SetMargins(this, pageMargins);
        }

        /// <summary>
        /// Adds a new paragraph to the section.
        /// </summary>
        /// <param name="newRun">Whether to create a run within the paragraph.</param>
        /// <returns>The created paragraph.</returns>
        public WordParagraph AddParagraph(bool newRun) {
            var wordParagraph = new WordParagraph(_document, newParagraph: true, newRun: newRun);
            if (this.Paragraphs.Count == 0) {
                WordParagraph paragraph = this._document.AddParagraph(wordParagraph);
                return paragraph;
            } else {
                WordParagraph lastParagraphWithinSection = this.Paragraphs.Last();
                WordParagraph paragraph = lastParagraphWithinSection.AddParagraphAfterSelf(this, wordParagraph);
                return paragraph;
            }
        }

        /// <summary>
        /// Adds a new paragraph containing the specified text.
        /// </summary>
        /// <param name="text">Text to place in the paragraph.</param>
        /// <returns>The created paragraph.</returns>
        public WordParagraph AddParagraph(string text = "") {
            if (this.Paragraphs.Count == 0) {
                WordParagraph paragraph = this._document.AddParagraph();
                if (text != "") {
                    paragraph.Text = text;
                }

                return paragraph;
            } else {
                WordParagraph lastParagraphWithinSection = this.Paragraphs.Last();

                WordParagraph paragraph = lastParagraphWithinSection.AddParagraphAfterSelf(this);
                paragraph._document = this._document;
                if (text != "") {
                    paragraph.Text = text;
                }

                return paragraph;
            }
        }

        /// <summary>
        /// Adds a watermark to the section.
        /// </summary>
        /// <param name="watermarkStyle">Watermark style.</param>
        /// <param name="textOrFilePath">Text or image file path.</param>
        /// <param name="horizontalOffset">Horizontal offset in points.</param>
        /// <param name="verticalOffset">Vertical offset in points.</param>
        /// <param name="scale">Scale factor for width and height.</param>
        /// <returns>The created <see cref="WordWatermark"/> instance.</returns>
        public WordWatermark AddWatermark(WordWatermarkStyle watermarkStyle, string textOrFilePath, double? horizontalOffset = null, double? verticalOffset = null, double scale = 1.0) {
            // return new WordWatermark(this._document, this, this.Header.Default, watermarkStyle, text);
            return new WordWatermark(this._document, this, watermarkStyle, textOrFilePath, horizontalOffset, verticalOffset, scale);
        }

        /// <summary>
        /// Removes all watermarks from this section including headers.
        /// </summary>
        public void RemoveWatermark() {
            foreach (var watermark in Watermarks.ToList()) {
                watermark.Remove();
            }
        }

        /// <summary>
        /// Applies border settings to the section.
        /// </summary>
        /// <param name="wordBorder">Border preset to apply.</param>
        /// <returns>The current section.</returns>
        public WordSection SetBorders(WordBorder wordBorder) {
            this.Borders.SetBorder(wordBorder);

            return this;
        }

        /// <summary>
        /// Inserts a horizontal line paragraph into the section.
        /// </summary>
        /// <param name="lineType">Border style of the line.</param>
        /// <param name="color">Line color.</param>
        /// <param name="size">Line width.</param>
        /// <param name="space">Line spacing.</param>
        /// <returns>The paragraph containing the line.</returns>
        public WordParagraph AddHorizontalLine(BorderValues? lineType = null, SixLabors.ImageSharp.Color? color = null, uint size = 12, uint space = 1) {
            lineType ??= BorderValues.Single;
            return this.AddParagraph("").AddHorizontalLine(lineType.Value, color, size, space);
        }

        /// <summary>
        /// Adds a hyperlink paragraph pointing to a URI.
        /// </summary>
        /// <param name="text">Display text.</param>
        /// <param name="uri">Target URI.</param>
        /// <param name="addStyle">Whether to apply hyperlink style.</param>
        /// <param name="tooltip">Optional tooltip.</param>
        /// <param name="history">Add to document history.</param>
        /// <returns>The created paragraph.</returns>
        public WordParagraph AddHyperLink(string text, Uri uri, bool addStyle = false, string tooltip = "", bool history = true) {
            return this.AddParagraph("").AddHyperLink(text, uri, addStyle, tooltip, history);
        }

        /// <summary>
        /// Adds a hyperlink paragraph pointing to an internal anchor.
        /// </summary>
        /// <param name="text">Display text.</param>
        /// <param name="anchor">Bookmark anchor name.</param>
        /// <param name="addStyle">Whether to apply hyperlink style.</param>
        /// <param name="tooltip">Optional tooltip.</param>
        /// <param name="history">Add to document history.</param>
        /// <returns>The created paragraph.</returns>
        public WordParagraph AddHyperLink(string text, string anchor, bool addStyle = false, string tooltip = "", bool history = true) {
            return this.AddParagraph("").AddHyperLink(text, anchor, addStyle, tooltip, history);
        }

        /// <summary>
        /// Adds default headers and footers to the section.
        /// </summary>
        public void AddHeadersAndFooters() {
            WordHeadersAndFooters.AddHeadersAndFooters(this);
        }

        /// <summary>
        /// Adds a text box paragraph to the section.
        /// </summary>
        /// <param name="text">Initial text inside the text box.</param>
        /// <param name="wrapTextImage">Wrapping style.</param>
        /// <returns>The created <see cref="WordTextBox"/>.</returns>
        public WordTextBox AddTextBox(string text, WrapTextImage wrapTextImage = WrapTextImage.Square) {
            return AddParagraph(newRun: true).AddTextBox(text, wrapTextImage);
        }

        /// <summary>
        /// Configures footnote properties for the section.
        /// </summary>
        /// <param name="numberingFormat">Numbering format.</param>
        /// <param name="position">Footnote position.</param>
        /// <param name="restartNumbering">Restart numbering option.</param>
        /// <param name="startNumber">Starting number.</param>
        /// <returns>The current section.</returns>
        public WordSection AddFootnoteProperties(NumberFormatValues? numberingFormat = null,
            FootnotePositionValues? position = null,
            RestartNumberValues? restartNumbering = null,
            int? startNumber = null) {
            var props = _sectionProperties.GetFirstChild<FootnoteProperties>();
            if (props == null) {
                props = new FootnoteProperties();
                _sectionProperties.Append(props);
            }

            props.RemoveAllChildren<NumberingFormat>();
            props.RemoveAllChildren<FootnotePosition>();
            props.RemoveAllChildren<NumberingRestart>();
            props.RemoveAllChildren<NumberingStart>();

            if (numberingFormat != null) {
                props.Append(new NumberingFormat() { Val = numberingFormat });
            }

            if (position != null) {
                props.Append(new FootnotePosition() { Val = position });
            }

            if (restartNumbering != null) {
                props.Append(new NumberingRestart() { Val = restartNumbering });
            }

            if (startNumber != null) {
                props.Append(new NumberingStart() { Val = (UInt16Value)startNumber.Value });
            }

            return this;
        }

        /// <summary>
        /// Configures endnote properties for the section.
        /// </summary>
        /// <param name="numberingFormat">Numbering format.</param>
        /// <param name="position">Endnote position.</param>
        /// <param name="restartNumbering">Restart numbering option.</param>
        /// <param name="startNumber">Starting number.</param>
        /// <returns>The current section.</returns>
        public WordSection AddEndnoteProperties(NumberFormatValues? numberingFormat = null,
            EndnotePositionValues? position = null,
            RestartNumberValues? restartNumbering = null,
            int? startNumber = null) {
            var props = _sectionProperties.GetFirstChild<EndnoteProperties>();
            if (props == null) {
                props = new EndnoteProperties();
                _sectionProperties.Append(props);
            }

            props.RemoveAllChildren<NumberingFormat>();
            props.RemoveAllChildren<EndnotePosition>();
            props.RemoveAllChildren<NumberingRestart>();
            props.RemoveAllChildren<NumberingStart>();

            if (numberingFormat != null) {
                props.Append(new NumberingFormat() { Val = numberingFormat });
            }

            if (position != null) {
                props.Append(new EndnotePosition() { Val = position });
            }

            if (restartNumbering != null) {
                props.Append(new NumberingRestart() { Val = restartNumbering });
            }

            if (startNumber != null) {
                props.Append(new NumberingStart() { Val = (UInt16Value)startNumber.Value });
            }

            return this;
        }

        /// <summary>
        /// Adds or updates page numbering for the section.
        /// </summary>
        /// <param name="startNumber">Starting page number.</param>
        /// <param name="format">Number format.</param>
        /// <returns>The current section.</returns>
        public WordSection AddPageNumbering(int? startNumber = null, NumberFormatValues? format = null) {
            var existing = _sectionProperties.GetFirstChild<PageNumberType>();
            existing?.Remove();

            if (startNumber != null || format != null) {
                var pageNumberType = new PageNumberType();
                if (format != null) {
                    pageNumberType.Format = format;
                }
                if (startNumber != null) {
                    pageNumberType.Start = startNumber.Value;
                }
                var refNode = _sectionProperties.Elements<FooterReference>().Cast<OpenXmlElement>()
                    .Concat(_sectionProperties.Elements<HeaderReference>()).LastOrDefault();
                if (refNode != null) {
                    _sectionProperties.InsertAfter(pageNumberType, refNode);
                } else {
                    _sectionProperties.InsertAt(pageNumberType, 0);
                }
            }

            return this;
        }

        /// <summary>
        /// Removes this section and all of its content from the document,
        /// cleaning up numbering and any unreferenced header and footer parts.
        /// </summary>
        public void RemoveSection() {
            foreach (var list in this.Lists.ToList()) {
                list.Remove();
            }

            foreach (var element in this.ElementsByType.ToList()) {
                switch (element) {
                    case WordParagraph paragraph:
                        paragraph.Remove();
                        break;
                    case WordTable table:
                        table.Remove();
                        break;
                    case WordTextBox textBox:
                        textBox.Remove();
                        break;
                    case WordImage image:
                        image.Remove();
                        break;
                    case WordEmbeddedDocument embedded:
                        embedded.Remove();
                        break;
                }
            }

            foreach (var headerRef in _sectionProperties.Elements<HeaderReference>().ToList()) {
                string id = headerRef.Id;
                bool usedElsewhere = _document.Sections
                    .Where(s => s != this)
                    .Any(s => s._sectionProperties.Elements<HeaderReference>().Any(hr => hr.Id == id));
                if (!usedElsewhere) {
                    var part = (HeaderPart)_document._wordprocessingDocument.MainDocumentPart.GetPartById(id);
                    _document._wordprocessingDocument.MainDocumentPart.DeletePart(part);
                }
                headerRef.Remove();
            }

            foreach (var footerRef in _sectionProperties.Elements<FooterReference>().ToList()) {
                string id = footerRef.Id;
                bool usedElsewhere = _document.Sections
                    .Where(s => s != this)
                    .Any(s => s._sectionProperties.Elements<FooterReference>().Any(fr => fr.Id == id));
                if (!usedElsewhere) {
                    var part = (FooterPart)_document._wordprocessingDocument.MainDocumentPart.GetPartById(id);
                    _document._wordprocessingDocument.MainDocumentPart.DeletePart(part);
                }
                footerRef.Remove();
            }

            if (_sectionProperties.Parent is Paragraph p) {
                p.Remove();
            } else if (_sectionProperties.Parent != null) {
                _sectionProperties.Remove();
            }

            _document.Sections.Remove(this);
        }
    }
}
