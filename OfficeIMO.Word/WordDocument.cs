﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeIMO.Word;

namespace OfficeIMO.Word {
    public partial class WordDocument : IDisposable {
        internal List<int> _listNumbersUsed = new List<int>();

        internal int BookmarkId {
            get {
                List<int> bookmarksList = new List<int>() { 0 };
                ;
                foreach (var paragraph in this.ParagraphsBookmarks) {
                    bookmarksList.Add(paragraph.Bookmark.Id);
                }

                return bookmarksList.Max() + 1;
            }
        }

        public WordTableOfContent TableOfContent {
            get {
                SdtBlock sdtBlock = _document.Body.ChildElements.OfType<SdtBlock>().FirstOrDefault();
                if (sdtBlock != null) {
                    return new WordTableOfContent(this, sdtBlock);
                }

                return null;
            }
        }

        public List<WordParagraph> Paragraphs {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Paragraphs);
                }

                return list;
            }
        }

        public List<WordParagraph> ParagraphsPageBreaks {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsPageBreaks);
                }

                return list;
            }
        }

        public List<WordParagraph> ParagraphsHyperLinks {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsHyperLinks);
                }

                return list;
            }
        }

        public List<WordParagraph> ParagraphsFields {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsFields);
                }

                return list;
            }
        }

        public List<WordParagraph> ParagraphsBookmarks {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsBookmarks);
                }

                return list;
            }
        }

        public List<WordParagraph> ParagraphsEquations {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsEquations);
                }

                return list;
            }
        }

        public List<WordParagraph> ParagraphsStructuredDocumentTags {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsStructuredDocumentTags);
                }

                return list;
            }
        }

        public List<WordPageBreak> PageBreaks {
            get {
                List<WordPageBreak> list = new List<WordPageBreak>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.PageBreaks);
                }

                return list;
            }
        }

        public List<WordComment> Comments {
            get { return WordComment.GetAllComments(this); }
        }

        public List<WordList> Lists {
            get {
                List<WordList> list = new List<WordList>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Lists);
                }

                return list;
            }
        }

        public List<WordBookmark> Bookmarks {
            get {
                List<WordBookmark> list = new List<WordBookmark>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Bookmarks);
                }

                return list;
            }
        }

        public List<WordTable> Tables {
            get {
                List<WordTable> list = new List<WordTable>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Tables);
                }

                return list;
            }
        }

        /// <summary>
        /// Provides a list of paragraphs that contain Image
        /// </summary>
        public List<WordParagraph> ParagraphsImages {
            get {
                List<WordParagraph> list = new List<WordParagraph>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.ParagraphsImages);
                }

                return list;
            }
        }

        /// <summary>
        /// Exposes Images in their Image form for easy access (saving, modifying)
        /// </summary>
        public List<WordImage> Images {
            get {
                List<WordImage> list = new List<WordImage>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Images);
                }

                return list;
            }
        }

        public List<WordField> Fields {
            get {
                List<WordField> list = new List<WordField>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Fields);
                }

                return list;
            }
        }

        public List<WordHyperLink> HyperLinks {
            get {
                List<WordHyperLink> list = new List<WordHyperLink>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.HyperLinks);
                }

                return list;
            }
        }

        public List<WordStructuredDocumentTag> StructuredDocumentTags {
            get {
                List<WordStructuredDocumentTag> list = new List<WordStructuredDocumentTag>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.StructuredDocumentTags);
                }

                return list;
            }
        }

        public List<WordEquation> Equations {
            get {
                List<WordEquation> list = new List<WordEquation>();
                foreach (var section in this.Sections) {
                    list.AddRange(section.Equations);
                }

                return list;
            }
        }

        public List<WordSection> Sections = new List<WordSection>();

        public string FilePath { get; set; }

        public WordSettings Settings;

        public ApplicationProperties ApplicationProperties;
        public BuiltinDocumentProperties BuiltinDocumentProperties;

        public readonly Dictionary<string, WordCustomProperty> CustomDocumentProperties = new Dictionary<string, WordCustomProperty>();

        public bool AutoSave => _wordprocessingDocument.AutoSave;

        internal WordprocessingDocument _wordprocessingDocument = null;
        public Document _document = null;
        public WordCustomProperties _customDocumentProperties;


        public FileAccess FileOpenAccess {
            get { return _wordprocessingDocument.MainDocumentPart.OpenXmlPackage.Package.FileOpenAccess; }
        }

        private static string GetUniqueFilePath(string filePath) {
            if (File.Exists(filePath)) {
                string folderPath = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);
                int number = 1;

                Match regex = Regex.Match(fileName, @"^(.+) \((\d+)\)$");

                if (regex.Success) {
                    fileName = regex.Groups[1].Value;
                    number = int.Parse(regex.Groups[2].Value);
                }

                do {
                    number++;
                    string newFileName = $"{fileName} ({number}){fileExtension}";
                    filePath = Path.Combine(folderPath, newFileName);
                } while (File.Exists(filePath));
            }

            return filePath;
        }

        public static WordDocument Create(string filePath = "", bool autoSave = false) {
            WordDocument word = new WordDocument();

            WordprocessingDocumentType documentType = WordprocessingDocumentType.Document;
            WordprocessingDocument wordDocument;

            if (filePath != "") {
                //System.IO.IOException: 'The process cannot access the file 'C:\Support\GitHub\OfficeIMO\OfficeIMO.Examples\bin\Debug\net5.0\Documents\Basic Document with some sections 1.docx' because it is being used by another process.'
                try {
                    wordDocument = WordprocessingDocument.Create(filePath, documentType, autoSave);
                } catch {
                    filePath = GetUniqueFilePath(filePath);
                    wordDocument = WordprocessingDocument.Create(filePath, documentType, autoSave);
                }
            } else {
                MemoryStream mem = new MemoryStream();
                //word._memory = mem;
                wordDocument = WordprocessingDocument.Create(mem, documentType, autoSave);
            }

            wordDocument.AddMainDocumentPart();
            wordDocument.MainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
            wordDocument.MainDocumentPart.Document.Body = new DocumentFormat.OpenXml.Wordprocessing.Body();

            word.FilePath = filePath;
            word._wordprocessingDocument = wordDocument;
            word._document = wordDocument.MainDocumentPart.Document;

            StyleDefinitionsPart styleDefinitionsPart1 = wordDocument.MainDocumentPart.AddNewPart<StyleDefinitionsPart>("rId1");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            WordSettings wordSettings = new WordSettings(word);
            ApplicationProperties applicationProperties = new ApplicationProperties(word);
            BuiltinDocumentProperties builtinDocumentProperties = new BuiltinDocumentProperties(word);
            //CustomDocumentProperties customDocumentProperties = new CustomDocumentProperties(word);
            WordSection wordSection = new WordSection(word, null);
            WordBackground wordBackground = new WordBackground(word);
            return word;
        }

        private void LoadDocument() {
            // add settings if not existing
            var wordSettings = new WordSettings(this);
            var applicationProperties = new ApplicationProperties(this);
            var builtinDocumentProperties = new BuiltinDocumentProperties(this);
            var wordCustomProperties = new WordCustomProperties(this);
            var wordBackground = new WordBackground(this);
            //CustomDocumentProperties customDocumentProperties = new CustomDocumentProperties(this);
            // add a section that's assigned to top of the document
            var wordSection = new WordSection(this, null, null);

            var list = this._wordprocessingDocument.MainDocumentPart.Document.Body.ChildElements.ToList(); //.OfType<Paragraph>().ToList();
            foreach (var element in list) {
                if (element is Paragraph) {
                    Paragraph paragraph = (Paragraph)element;
                    if (paragraph.ParagraphProperties != null && paragraph.ParagraphProperties.SectionProperties != null) {
                        wordSection = new WordSection(this, paragraph.ParagraphProperties.SectionProperties, paragraph);
                    }
                } else if (element is Table) {
                    // WordTable wordTable = new WordTable(this, wordSection, (Table)element);
                } else if (element is SectionProperties sectionProperties) {
                    // we don't do anything as we already created it above - i think
                } else if (element is SdtBlock sdtBlock) {
                    // we don't do anything as we load stuff with get on demand
                } else if (element is OpenXmlUnknownElement) {
                    // this happens when adding dirty element - mainly during TOC Update() function
                } else {
                    throw new NotImplementedException("This isn't implemented yet");
                }
            }

            RearrangeSectionsAfterLoad();
        }

        private void RearrangeSectionsAfterLoad() {
            if (Sections.Count > 0) {
                //var firstElement = Sections[0];
                var firstElementHeader = Sections[0].Header;
                var firstElementFooter = Sections[0].Footer;
                var firstElementSection = Sections[0]._sectionProperties;

                for (int i = 0; i < Sections.Count; i++) {
                    var element = Sections[i];
                    //var tempFooter = element.Footer;
                    //var tempHeader = element.Header;
                    //var tempSectionProp = element._sectionProperties;

                    if (i + 1 < Sections.Count) {
                        Sections[i].Footer = Sections[i + 1].Footer;
                        Sections[i].Header = Sections[i + 1].Header;
                        Sections[i]._sectionProperties = Sections[i + 1]._sectionProperties;

                        Sections[i + 1].Footer = element.Footer;
                        Sections[i + 1].Header = element.Header;
                        Sections[i + 1]._sectionProperties = element._sectionProperties;
                    } else {
                        Sections[i].Footer = firstElementFooter;
                        Sections[i].Header = firstElementHeader;
                        Sections[i]._sectionProperties = firstElementSection;
                    }
                }
            }
        }

        public static WordDocument Load(string filePath, bool readOnly = false, bool autoSave = false) {
            if (filePath != null) {
                if (!File.Exists(filePath)) {
                    throw new FileNotFoundException("File doesn't exists", filePath);
                }
            }

            WordDocument word = new WordDocument();

            var openSettings = new OpenSettings {
                AutoSave = autoSave
            };

            // this seems to solve an issue where custom properties wouldn't want to save when opening file
            // no problem with creating empty
            FileMode fileMode = readOnly ? FileMode.Open : FileMode.OpenOrCreate;
            var package = Package.Open(filePath, fileMode);
            //WordprocessingDocument wordDocument = WordprocessingDocument.Open(filePath, readOnly, openSettings);
            WordprocessingDocument wordDocument = WordprocessingDocument.Open(package, openSettings);
            word.FilePath = filePath;
            word._wordprocessingDocument = wordDocument;
            word._document = wordDocument.MainDocumentPart.Document;
            word.LoadDocument();
            return word;
        }

        public void Open(bool openWord = true) {
            this.Open("", openWord);
        }

        public void Open(string filePath = "", bool openWord = true) {
            if (filePath == "") {
                filePath = this.FilePath;
            }

            Helpers.Open(filePath, openWord);
        }


        //private void LoadNumbering() {
        //    if (_wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart != null) {
        //        Numbering numbering = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering;
        //        if (numbering == null) {
        //        } else {
        //            var tempAbstractNumList = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<AbstractNum>();
        //            foreach (AbstractNum abstractNum in tempAbstractNumList) {
        //               // _ListAbstractNum.Add(abstractNum);
        //            }

        //            var tempNumberingInstance = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<NumberingInstance>();
        //            foreach (NumberingInstance numberingInstance in tempNumberingInstance) {
        //                //_listNumberingInstances.Add(numberingInstance);
        //            }
        //        }
        //    }
        //}
        //private void SaveSections() {
        //    WordSection temporarySection = null;
        //    if (this.Sections.Count > 0) {
        //        for (int i = 0; i < Sections.Count; i++) {
        //            if (temporarySection != null) {

        //            } else {
        //                temporarySection = Sections[i];
        //                Sections[i]._sectionProperties.Remove();
        //            }
        //        }
        //    }
        //}

        private void SaveNumbering() {
            // it seems the order of numbering instance/abstractnums in numbering matters...
            List<AbstractNum> listAbstractNum = new List<AbstractNum>();
            List<NumberingInstance> listNumberingInstance = new List<NumberingInstance>();

            if (_wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart != null) {
                var tempAbstractNumList = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<AbstractNum>();
                foreach (AbstractNum abstractNum in tempAbstractNumList) {
                    listAbstractNum.Add(abstractNum);
                }

                var tempNumberingInstance = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<NumberingInstance>();
                foreach (NumberingInstance numberingInstance in tempNumberingInstance) {
                    listNumberingInstance.Add(numberingInstance);
                }

                if (_wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart != null) {
                    Numbering numbering = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering;
                    if (numbering != null) {
                        numbering.RemoveAllChildren();
                    }
                }

                //var tempAbstractNumList = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<AbstractNum>();
                //foreach (AbstractNum abstractNum in tempAbstractNumList) {
                //    abstractNum.Remove();
                //}
                //var tempNumberingInstance = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<NumberingInstance>();
                //foreach (NumberingInstance numberingInstance in tempNumberingInstance) {
                //    numberingInstance.Remove();
                //}
                //tempNumberingInstance = _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.ChildElements.OfType<NumberingInstance>();

                foreach (AbstractNum abstractNum in listAbstractNum) {
                    _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.Append(abstractNum);
                }

                foreach (NumberingInstance numberingInstance in listNumberingInstance) {
                    _wordprocessingDocument.MainDocumentPart.NumberingDefinitionsPart.Numbering.Append(numberingInstance);
                }
            }
        }

        public void Save(string filePath, bool openWord) {
            MoveSectionProperties();
            SaveNumbering();
            WordCustomProperties wordCustomProperties = new WordCustomProperties(this, true);

            if (this._wordprocessingDocument != null) {
                try {
                    if (filePath != "") {
                        // doesn't work correctly with packages
                        this._wordprocessingDocument.SaveAs(filePath);
                    } else {
                        this._wordprocessingDocument.Save();
                    }
                } catch {
                    throw;
                } finally {
                    this._wordprocessingDocument.Close();
                    this._wordprocessingDocument.Dispose();
                }
            } else {
                throw new InvalidOperationException("Document couldn't be saved as WordDocument wasn't provided.");
            }

            this.Open(filePath, openWord);
        }

        public void Save() {
            this.Save("", false);
        }

        public void Save(string filePath) {
            this.Save(filePath, false);
        }

        public void Save(bool openWord) {
            this.Save("", openWord);
        }

        /// <summary>
        /// This moves section within body from top to bottom to allow footers/headers to move
        /// Needs more work, but this is what Word does all the time
        /// </summary>
        private void MoveSectionProperties() {
            var body = this._wordprocessingDocument.MainDocumentPart.Document.Body;
            var sectionProperties = this._wordprocessingDocument.MainDocumentPart.Document.Body.Elements<SectionProperties>().Last();
            body.RemoveChild(sectionProperties);
            body.Append(sectionProperties);
        }

        public WordParagraph AddParagraph(WordParagraph wordParagraph = null) {
            if (wordParagraph == null) {
                // we create paragraph (and within that add it to document)
                wordParagraph = new WordParagraph(this);
            } else {
                // since we created paragraph without adding it to document, we now need to add it to document
                //this.Paragraphs.Add(wordParagraph);
            }

            //this._currentSection.Paragraphs.Add(wordParagraph);
            // wordParagraph._section = this._currentSection;
            this._wordprocessingDocument.MainDocumentPart.Document.Body.AppendChild(wordParagraph._paragraph);
            return wordParagraph;
        }

        public WordParagraph AddParagraph(string text) {
            return AddParagraph().SetText(text);
        }

        public WordParagraph AddPageBreak() {
            WordParagraph newWordParagraph = new WordParagraph {
                _run = new Run(new Break() { Type = BreakValues.Page }),
                _document = this
            };
            newWordParagraph._paragraph = new Paragraph(newWordParagraph._run);

            this._document.Body.Append(newWordParagraph._paragraph);
            return newWordParagraph;
        }

        public WordParagraph AddBreak(BreakValues breakType = BreakValues.Page) {
            WordParagraph newWordParagraph = new WordParagraph {
                _run = new Run(new Break() { Type = breakType }),
                _document = this
            };
            newWordParagraph._paragraph = new Paragraph(newWordParagraph._run);

            this._document.Body.Append(newWordParagraph._paragraph);
            this.Paragraphs.Add(newWordParagraph);
            return newWordParagraph;
        }

        public void Dispose() {
            if (this._wordprocessingDocument != null) {
                //this._wordprocessingDocument.Close();
                this._wordprocessingDocument.Dispose();
            }
        }

        public WordSection AddSection(SectionMarkValues? sectionMark = null) {
            //Paragraph paragraph = new Paragraph() { RsidParagraphAddition = "fff0", RsidRunAdditionDefault = "fff0"};
            Paragraph paragraph = new Paragraph();

            ParagraphProperties paragraphProperties = new ParagraphProperties();

            SectionProperties sectionProperties = new SectionProperties();
            // SectionProperties sectionProperties = new SectionProperties() { RsidR = "fff0"  };

            if (sectionMark != null) {
                SectionType sectionType = new SectionType() { Val = sectionMark };
                sectionProperties.Append(sectionType);
            }

            paragraphProperties.Append(sectionProperties);
            paragraph.Append(paragraphProperties);


            this._document.MainDocumentPart.Document.Body.Append(paragraph);


            WordSection wordSection = new WordSection(this, paragraph);

            return wordSection;
        }

        internal WordSection _currentSection => this.Sections.Last();


        public WordBackground Background { get; set; }

        public bool DocumentIsValid {
            get {
                if (DocumentValidationErrors.Count > 0) {
                    return false;
                }

                return true;
            }
        }

        public List<ValidationErrorInfo> DocumentValidationErrors {
            get {
                List<ValidationErrorInfo> listErrors = new List<ValidationErrorInfo>();
                OpenXmlValidator validator = new OpenXmlValidator();
                foreach (ValidationErrorInfo error in validator.Validate(this._wordprocessingDocument)) {
                    listErrors.Add(error);
                }

                return listErrors;
            }
        }

        public WordList AddList(WordListStyle style) {
            WordList wordList = new WordList(this, this._currentSection);
            wordList.AddList(style);
            return wordList;
        }

        public WordList AddTableOfContentList(WordListStyle style) {
            WordList wordList = new WordList(this, this._currentSection, true);
            wordList.AddList(style);
            return wordList;
        }

        public WordTable AddTable(int rows, int columns, WordTableStyle tableStyle = WordTableStyle.TableGrid) {
            WordTable wordTable = new WordTable(this, this._currentSection, rows, columns, tableStyle);
            return wordTable;
        }

        public WordTableOfContent AddTableOfContent(TableOfContentStyle tableOfContentStyle = TableOfContentStyle.Template1) {
            WordTableOfContent wordTableContent = new WordTableOfContent(this, tableOfContentStyle);
            return wordTableContent;
        }

        public WordParagraph AddHorizontalLine(BorderValues lineType = BorderValues.Single, System.Drawing.Color? color = null, uint size = 12, uint space = 1) {
            return this.AddParagraph().AddHorizontalLine(lineType, color, size, space);
        }
    }
}