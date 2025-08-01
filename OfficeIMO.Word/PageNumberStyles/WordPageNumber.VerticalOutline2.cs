using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using Wpg = DocumentFormat.OpenXml.Office2010.Word.DrawingGroup;
using Wps = DocumentFormat.OpenXml.Office2010.Word.DrawingShape;
using A14 = DocumentFormat.OpenXml.Office2010.Drawing;
using Wp14 = DocumentFormat.OpenXml.Office2010.Word.Drawing;
using V = DocumentFormat.OpenXml.Vml;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using Wvml = DocumentFormat.OpenXml.Vml.Wordprocessing;

namespace OfficeIMO.Word;

/// <summary>
/// Represents a page-numbering building block.
/// </summary>
public partial class WordPageNumber {
    private static SdtBlock VerticalOutline2 {
        get {
            SdtBlock sdtBlock1 = new SdtBlock();

            SdtProperties sdtProperties1 = new SdtProperties();
            SdtId sdtId1 = new SdtId() { Val = -1315946405 };

            SdtContentDocPartObject sdtContentDocPartObject1 = new SdtContentDocPartObject();
            DocPartGallery docPartGallery1 = new DocPartGallery() { Val = "Page Numbers (Top of Page)" };
            DocPartUnique docPartUnique1 = new DocPartUnique();

            sdtContentDocPartObject1.Append(docPartGallery1);
            sdtContentDocPartObject1.Append(docPartUnique1);

            sdtProperties1.Append(sdtId1);
            sdtProperties1.Append(sdtContentDocPartObject1);

            SdtContentBlock sdtContentBlock1 = new SdtContentBlock();

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "002C0D80", RsidParagraphAddition = "00E11B1E", RsidParagraphProperties = "002C0D80", RsidRunAdditionDefault = "002C0D80", ParagraphId = "16AD3494", TextId = "179C0DC2" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Header" };

            paragraphProperties1.Append(paragraphStyleId1);

            Run run1 = new Run();

            RunProperties runProperties1 = new RunProperties();
            NoProof noProof1 = new NoProof();

            runProperties1.Append(noProof1);

            AlternateContent alternateContent1 = new AlternateContent();

            AlternateContentChoice alternateContentChoice1 = new AlternateContentChoice() { Requires = "wpg" };

            Drawing drawing1 = new Drawing();

            Wp.Anchor anchor1 = new Wp.Anchor() { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)114300U, DistanceFromRight = (UInt32Value)114300U, SimplePos = false, RelativeHeight = (UInt32Value)251659264U, BehindDoc = false, Locked = false, LayoutInCell = false, AllowOverlap = true, EditId = "0E69DD95", AnchorId = "028B62BF" };
            Wp.SimplePosition simplePosition1 = new Wp.SimplePosition() { X = 0L, Y = 0L };

            Wp.HorizontalPosition horizontalPosition1 = new Wp.HorizontalPosition() { RelativeFrom = Wp.HorizontalRelativePositionValues.RightMargin };
            Wp.HorizontalAlignment horizontalAlignment1 = new Wp.HorizontalAlignment();
            horizontalAlignment1.Text = "left";

            horizontalPosition1.Append(horizontalAlignment1);

            Wp.VerticalPosition verticalPosition1 = new Wp.VerticalPosition() { RelativeFrom = Wp.VerticalRelativePositionValues.Margin };
            Wp.VerticalAlignment verticalAlignment1 = new Wp.VerticalAlignment();
            verticalAlignment1.Text = "top";

            verticalPosition1.Append(verticalAlignment1);
            Wp.Extent extent1 = new Wp.Extent() { Cx = 902335L, Cy = 1902460L };
            Wp.EffectExtent effectExtent1 = new Wp.EffectExtent() { LeftEdge = 0L, TopEdge = 9525L, RightEdge = 12065L, BottomEdge = 2540L };
            Wp.WrapNone wrapNone1 = new Wp.WrapNone();
            Wp.DocProperties docProperties1 = new Wp.DocProperties() { Id = (UInt32Value)15U, Name = "Group 15" };

            Wp.NonVisualGraphicFrameDrawingProperties nonVisualGraphicFrameDrawingProperties1 = new Wp.NonVisualGraphicFrameDrawingProperties();

            A.GraphicFrameLocks graphicFrameLocks1 = new A.GraphicFrameLocks();
            graphicFrameLocks1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            nonVisualGraphicFrameDrawingProperties1.Append(graphicFrameLocks1);

            A.Graphic graphic1 = new A.Graphic();
            graphic1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.GraphicData graphicData1 = new A.GraphicData() { Uri = "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup" };

            Wpg.WordprocessingGroup wordprocessingGroup1 = new Wpg.WordprocessingGroup();

            Wpg.NonVisualGroupDrawingShapeProperties nonVisualGroupDrawingShapeProperties1 = new Wpg.NonVisualGroupDrawingShapeProperties();
            A.GroupShapeLocks groupShapeLocks1 = new A.GroupShapeLocks();

            nonVisualGroupDrawingShapeProperties1.Append(groupShapeLocks1);

            Wpg.GroupShapeProperties groupShapeProperties1 = new Wpg.GroupShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.TransformGroup transformGroup1 = new A.TransformGroup() { HorizontalFlip = true, VerticalFlip = true };
            A.Offset offset1 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents1 = new A.Extents() { Cx = 902335L, Cy = 1902460L };
            A.ChildOffset childOffset1 = new A.ChildOffset() { X = 13L, Y = 11415L };
            A.ChildExtents childExtents1 = new A.ChildExtents() { Cx = 1425L, Cy = 2996L };

            transformGroup1.Append(offset1);
            transformGroup1.Append(extents1);
            transformGroup1.Append(childOffset1);
            transformGroup1.Append(childExtents1);

            groupShapeProperties1.Append(transformGroup1);

            Wpg.GroupShape groupShape1 = new Wpg.GroupShape();
            Wpg.NonVisualDrawingProperties nonVisualDrawingProperties1 = new Wpg.NonVisualDrawingProperties() { Id = (UInt32Value)16U, Name = "Group 7" };

            Wpg.NonVisualGroupDrawingShapeProperties nonVisualGroupDrawingShapeProperties2 = new Wpg.NonVisualGroupDrawingShapeProperties();
            A.GroupShapeLocks groupShapeLocks2 = new A.GroupShapeLocks();

            nonVisualGroupDrawingShapeProperties2.Append(groupShapeLocks2);

            Wpg.GroupShapeProperties groupShapeProperties2 = new Wpg.GroupShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.TransformGroup transformGroup2 = new A.TransformGroup() { VerticalFlip = true };
            A.Offset offset2 = new A.Offset() { X = 13L, Y = 14340L };
            A.Extents extents2 = new A.Extents() { Cx = 1410L, Cy = 71L };
            A.ChildOffset childOffset2 = new A.ChildOffset() { X = -83L, Y = 540L };
            A.ChildExtents childExtents2 = new A.ChildExtents() { Cx = 1218L, Cy = 71L };

            transformGroup2.Append(offset2);
            transformGroup2.Append(extents2);
            transformGroup2.Append(childOffset2);
            transformGroup2.Append(childExtents2);

            groupShapeProperties2.Append(transformGroup2);

            Wps.WordprocessingShape wordprocessingShape1 = new Wps.WordprocessingShape();
            Wps.NonVisualDrawingProperties nonVisualDrawingProperties2 = new Wps.NonVisualDrawingProperties() { Id = (UInt32Value)17U, Name = "Rectangle 8" };

            Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties1 = new Wps.NonVisualDrawingShapeProperties();
            A.ShapeLocks shapeLocks1 = new A.ShapeLocks() { NoChangeArrowheads = true };

            nonVisualDrawingShapeProperties1.Append(shapeLocks1);

            Wps.ShapeProperties shapeProperties1 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.Transform2D transform2D1 = new A.Transform2D();
            A.Offset offset3 = new A.Offset() { X = 678L, Y = 540L };
            A.Extents extents3 = new A.Extents() { Cx = 457L, Cy = 71L };

            transform2D1.Append(offset3);
            transform2D1.Append(extents3);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            A.SolidFill solidFill1 = new A.SolidFill();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "5F497A" };

            solidFill1.Append(rgbColorModelHex1);

            A.Outline outline1 = new A.Outline() { Width = 9525 };

            A.SolidFill solidFill2 = new A.SolidFill();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "5F497A" };

            solidFill2.Append(rgbColorModelHex2);
            A.Miter miter1 = new A.Miter() { Limit = 800000 };
            A.HeadEnd headEnd1 = new A.HeadEnd();
            A.TailEnd tailEnd1 = new A.TailEnd();

            outline1.Append(solidFill2);
            outline1.Append(miter1);
            outline1.Append(headEnd1);
            outline1.Append(tailEnd1);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            shapeProperties1.Append(solidFill1);
            shapeProperties1.Append(outline1);

            Wps.TextBodyProperties textBodyProperties1 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Horizontal, Wrap = A.TextWrappingValues.Square, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false, UpRight = true };
            A.NoAutoFit noAutoFit1 = new A.NoAutoFit();

            textBodyProperties1.Append(noAutoFit1);

            wordprocessingShape1.Append(nonVisualDrawingProperties2);
            wordprocessingShape1.Append(nonVisualDrawingShapeProperties1);
            wordprocessingShape1.Append(shapeProperties1);
            wordprocessingShape1.Append(textBodyProperties1);

            Wps.WordprocessingShape wordprocessingShape2 = new Wps.WordprocessingShape();
            Wps.NonVisualDrawingProperties nonVisualDrawingProperties3 = new Wps.NonVisualDrawingProperties() { Id = (UInt32Value)18U, Name = "AutoShape 9" };

            Wps.NonVisualConnectorProperties nonVisualConnectorProperties1 = new Wps.NonVisualConnectorProperties();
            A.ConnectionShapeLocks connectionShapeLocks1 = new A.ConnectionShapeLocks() { NoChangeShapeType = true };

            nonVisualConnectorProperties1.Append(connectionShapeLocks1);

            Wps.ShapeProperties shapeProperties2 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.Transform2D transform2D2 = new A.Transform2D() { HorizontalFlip = true };
            A.Offset offset4 = new A.Offset() { X = -83L, Y = 540L };
            A.Extents extents4 = new A.Extents() { Cx = 761L, Cy = 0L };

            transform2D2.Append(offset4);
            transform2D2.Append(extents4);

            A.PresetGeometry presetGeometry2 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.StraightConnector1 };
            A.AdjustValueList adjustValueList2 = new A.AdjustValueList();

            presetGeometry2.Append(adjustValueList2);
            A.NoFill noFill1 = new A.NoFill();

            A.Outline outline2 = new A.Outline() { Width = 9525 };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "5F497A" };

            solidFill3.Append(rgbColorModelHex3);
            A.Round round1 = new A.Round();
            A.HeadEnd headEnd2 = new A.HeadEnd();
            A.TailEnd tailEnd2 = new A.TailEnd();

            outline2.Append(solidFill3);
            outline2.Append(round1);
            outline2.Append(headEnd2);
            outline2.Append(tailEnd2);

            A.ShapePropertiesExtensionList shapePropertiesExtensionList1 = new A.ShapePropertiesExtensionList();

            A.ShapePropertiesExtension shapePropertiesExtension1 = new A.ShapePropertiesExtension() { Uri = "{909E8E84-426E-40DD-AFC4-6F175D3DCCD1}" };

            A14.HiddenFillProperties hiddenFillProperties1 = new A14.HiddenFillProperties();
            hiddenFillProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");
            A.NoFill noFill2 = new A.NoFill();

            hiddenFillProperties1.Append(noFill2);

            shapePropertiesExtension1.Append(hiddenFillProperties1);

            shapePropertiesExtensionList1.Append(shapePropertiesExtension1);

            shapeProperties2.Append(transform2D2);
            shapeProperties2.Append(presetGeometry2);
            shapeProperties2.Append(noFill1);
            shapeProperties2.Append(outline2);
            shapeProperties2.Append(shapePropertiesExtensionList1);
            Wps.TextBodyProperties textBodyProperties2 = new Wps.TextBodyProperties();

            wordprocessingShape2.Append(nonVisualDrawingProperties3);
            wordprocessingShape2.Append(nonVisualConnectorProperties1);
            wordprocessingShape2.Append(shapeProperties2);
            wordprocessingShape2.Append(textBodyProperties2);

            groupShape1.Append(nonVisualDrawingProperties1);
            groupShape1.Append(nonVisualGroupDrawingShapeProperties2);
            groupShape1.Append(groupShapeProperties2);
            groupShape1.Append(wordprocessingShape1);
            groupShape1.Append(wordprocessingShape2);

            Wps.WordprocessingShape wordprocessingShape3 = new Wps.WordprocessingShape();
            Wps.NonVisualDrawingProperties nonVisualDrawingProperties4 = new Wps.NonVisualDrawingProperties() { Id = (UInt32Value)19U, Name = "Rectangle 10" };

            Wps.NonVisualDrawingShapeProperties nonVisualDrawingShapeProperties2 = new Wps.NonVisualDrawingShapeProperties();
            A.ShapeLocks shapeLocks2 = new A.ShapeLocks() { NoChangeArrowheads = true };

            nonVisualDrawingShapeProperties2.Append(shapeLocks2);

            Wps.ShapeProperties shapeProperties3 = new Wps.ShapeProperties() { BlackWhiteMode = A.BlackWhiteModeValues.Auto };

            A.Transform2D transform2D3 = new A.Transform2D();
            A.Offset offset5 = new A.Offset() { X = 405L, Y = 11415L };
            A.Extents extents5 = new A.Extents() { Cx = 1033L, Cy = 2805L };

            transform2D3.Append(offset5);
            transform2D3.Append(extents5);

            A.PresetGeometry presetGeometry3 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList3 = new A.AdjustValueList();

            presetGeometry3.Append(adjustValueList3);

            A.SolidFill solidFill4 = new A.SolidFill();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "FFFFFF" };

            solidFill4.Append(rgbColorModelHex4);

            A.Outline outline3 = new A.Outline();
            A.NoFill noFill3 = new A.NoFill();

            outline3.Append(noFill3);

            A.ShapePropertiesExtensionList shapePropertiesExtensionList2 = new A.ShapePropertiesExtensionList();

            A.ShapePropertiesExtension shapePropertiesExtension2 = new A.ShapePropertiesExtension() { Uri = "{91240B29-F687-4F45-9708-019B960494DF}" };

            A14.HiddenLineProperties hiddenLineProperties1 = new A14.HiddenLineProperties() { Width = 9525 };
            hiddenLineProperties1.AddNamespaceDeclaration("a14", "http://schemas.microsoft.com/office/drawing/2010/main");

            A.SolidFill solidFill5 = new A.SolidFill();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "000000" };

            solidFill5.Append(rgbColorModelHex5);
            A.Miter miter2 = new A.Miter() { Limit = 800000 };
            A.HeadEnd headEnd3 = new A.HeadEnd();
            A.TailEnd tailEnd3 = new A.TailEnd();

            hiddenLineProperties1.Append(solidFill5);
            hiddenLineProperties1.Append(miter2);
            hiddenLineProperties1.Append(headEnd3);
            hiddenLineProperties1.Append(tailEnd3);

            shapePropertiesExtension2.Append(hiddenLineProperties1);

            shapePropertiesExtensionList2.Append(shapePropertiesExtension2);

            shapeProperties3.Append(transform2D3);
            shapeProperties3.Append(presetGeometry3);
            shapeProperties3.Append(solidFill4);
            shapeProperties3.Append(outline3);
            shapeProperties3.Append(shapePropertiesExtensionList2);

            Wps.TextBoxInfo2 textBoxInfo21 = new Wps.TextBoxInfo2();

            TextBoxContent textBoxContent1 = new TextBoxContent();

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "002C0D80", RsidRunAdditionDefault = "002C0D80", ParagraphId = "3857EF7C", TextId = "77777777" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification1 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties2.Append(paragraphStyleId2);
            paragraphProperties2.Append(justification1);

            Run run2 = new Run();
            FieldChar fieldChar1 = new FieldChar() { FieldCharType = FieldCharValues.Begin };

            run2.Append(fieldChar1);

            Run run3 = new Run();
            FieldCode fieldCode1 = new FieldCode() { Space = SpaceProcessingModeValues.Preserve };
            fieldCode1.Text = " PAGE    \\* MERGEFORMAT ";

            run3.Append(fieldCode1);

            Run run4 = new Run();
            FieldChar fieldChar2 = new FieldChar() { FieldCharType = FieldCharValues.Separate };

            run4.Append(fieldChar2);

            Run run5 = new Run();

            RunProperties runProperties2 = new RunProperties();
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            NoProof noProof2 = new NoProof();
            Color color1 = new Color() { Val = "BF8F00", ThemeColor = ThemeColorValues.Accent4, ThemeShade = "BF" };
            FontSize fontSize1 = new FontSize() { Val = "52" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "52" };

            runProperties2.Append(bold1);
            runProperties2.Append(boldComplexScript1);
            runProperties2.Append(noProof2);
            runProperties2.Append(color1);
            runProperties2.Append(fontSize1);
            runProperties2.Append(fontSizeComplexScript1);
            Text text1 = new Text();
            text1.Text = "2";

            run5.Append(runProperties2);
            run5.Append(text1);

            Run run6 = new Run();

            RunProperties runProperties3 = new RunProperties();
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();
            NoProof noProof3 = new NoProof();
            Color color2 = new Color() { Val = "BF8F00", ThemeColor = ThemeColorValues.Accent4, ThemeShade = "BF" };
            FontSize fontSize2 = new FontSize() { Val = "52" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "52" };

            runProperties3.Append(bold2);
            runProperties3.Append(boldComplexScript2);
            runProperties3.Append(noProof3);
            runProperties3.Append(color2);
            runProperties3.Append(fontSize2);
            runProperties3.Append(fontSizeComplexScript2);
            FieldChar fieldChar3 = new FieldChar() { FieldCharType = FieldCharValues.End };

            run6.Append(runProperties3);
            run6.Append(fieldChar3);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run2);
            paragraph2.Append(run3);
            paragraph2.Append(run4);
            paragraph2.Append(run5);
            paragraph2.Append(run6);

            textBoxContent1.Append(paragraph2);

            textBoxInfo21.Append(textBoxContent1);

            Wps.TextBodyProperties textBodyProperties3 = new Wps.TextBodyProperties() { Rotation = 0, Vertical = A.TextVerticalValues.Vertical270, Wrap = A.TextWrappingValues.Square, LeftInset = 0, TopInset = 0, RightInset = 0, BottomInset = 0, Anchor = A.TextAnchoringTypeValues.Top, AnchorCenter = false, UpRight = true };
            A.NoAutoFit noAutoFit2 = new A.NoAutoFit();

            textBodyProperties3.Append(noAutoFit2);

            wordprocessingShape3.Append(nonVisualDrawingProperties4);
            wordprocessingShape3.Append(nonVisualDrawingShapeProperties2);
            wordprocessingShape3.Append(shapeProperties3);
            wordprocessingShape3.Append(textBoxInfo21);
            wordprocessingShape3.Append(textBodyProperties3);

            wordprocessingGroup1.Append(nonVisualGroupDrawingShapeProperties1);
            wordprocessingGroup1.Append(groupShapeProperties1);
            wordprocessingGroup1.Append(groupShape1);
            wordprocessingGroup1.Append(wordprocessingShape3);

            graphicData1.Append(wordprocessingGroup1);

            graphic1.Append(graphicData1);

            Wp14.RelativeWidth relativeWidth1 = new Wp14.RelativeWidth() { ObjectId = Wp14.SizeRelativeHorizontallyValues.LeftMargin };
            Wp14.PercentageWidth percentageWidth1 = new Wp14.PercentageWidth();
            percentageWidth1.Text = "100000";

            relativeWidth1.Append(percentageWidth1);

            Wp14.RelativeHeight relativeHeight1 = new Wp14.RelativeHeight() { RelativeFrom = Wp14.SizeRelativeVerticallyValues.Page };
            Wp14.PercentageHeight percentageHeight1 = new Wp14.PercentageHeight();
            percentageHeight1.Text = "0";

            relativeHeight1.Append(percentageHeight1);

            anchor1.Append(simplePosition1);
            anchor1.Append(horizontalPosition1);
            anchor1.Append(verticalPosition1);
            anchor1.Append(extent1);
            anchor1.Append(effectExtent1);
            anchor1.Append(wrapNone1);
            anchor1.Append(docProperties1);
            anchor1.Append(nonVisualGraphicFrameDrawingProperties1);
            anchor1.Append(graphic1);
            anchor1.Append(relativeWidth1);
            anchor1.Append(relativeHeight1);

            drawing1.Append(anchor1);

            alternateContentChoice1.Append(drawing1);

            AlternateContentFallback alternateContentFallback1 = new AlternateContentFallback();

            Picture picture1 = new Picture();

            V.Group group1 = new V.Group() { Id = "Group 15", Style = "position:absolute;margin-left:0;margin-top:0;width:71.05pt;height:149.8pt;flip:x y;z-index:251659264;mso-width-percent:1000;mso-position-horizontal:left;mso-position-horizontal-relative:right-margin-area;mso-position-vertical:top;mso-position-vertical-relative:margin;mso-width-percent:1000;mso-width-relative:left-margin-area", CoordinateSize = "1425,2996", CoordinateOrigin = "13,11415", OptionalString = "_x0000_s1026", AllowInCell = false };
            group1.SetAttribute(new OpenXmlAttribute("o", "gfxdata", "urn:schemas-microsoft-com:office:office", "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\n"));

            V.Group group2 = new V.Group() { Id = "Group 7", Style = "position:absolute;left:13;top:14340;width:1410;height:71;flip:y", CoordinateSize = "1218,71", CoordinateOrigin = "-83,540", OptionalString = "_x0000_s1027" };
            group2.SetAttribute(new OpenXmlAttribute("o", "gfxdata", "urn:schemas-microsoft-com:office:office", "UEsDBBQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbHyQz07DMAyH\n70i8Q+QralM4IITa7kDhCAiNB7ASt43WOlEcyvb2pNu4IODoPz9/n1xv9vOkForiPDdwXVagiI23\njocG3rdPxR0oScgWJ8/UwIEENu3lRb09BBKV0ywNjCmFe63FjDSjlD4Q50nv44wpl3HQAc0OB9I3\nVXWrjedEnIq03oC27qjHjympx31un0wiTQLq4bS4shrAECZnMGVTvbD9QSnOhDInjzsyuiBXWQP0\nr4R18jfgnHvJr4nOknrFmJ5xzhraRtHWf3Kkpfz/yGo5S+H73hkquyhdjr3R8m2lj09svwAAAP//\nAwBQSwMEFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsAAABfcmVscy8ucmVsc2zPwWrDMAwG4Ptg72B0\nX5TuUMaI01uh19I+gLGVxCy2jGSy9e1nemrHjpL4P0nD4SetZiPRyNnCruvBUPYcYp4tXC/Htw8w\nWl0ObuVMFm6kcBhfX4Yzra62kC6xqGlKVgtLreUTUf1CyWnHhXKbTCzJ1VbKjMX5LzcTvvf9HuXR\ngPHJNKdgQU5hB+ZyK23zHztFL6w81c5zQp6m6P9TMfB3PtPWFCczVQtB9N4U2rp2HOA44NMz4y8A\nAAD//wMAUEsDBBQABgAIAAAAIQCvT5vfwQAAANsAAAAPAAAAZHJzL2Rvd25yZXYueG1sRE/JasMw\nEL0H+g9iAr0lcooJwbESQqAllF7qLPg4WBNbxBoZS7Xdv68Khd7m8dbJ95NtxUC9N44VrJYJCOLK\nacO1gsv5dbEB4QOyxtYxKfgmD/vd0yzHTLuRP2koQi1iCPsMFTQhdJmUvmrIol+6jjhyd9dbDBH2\ntdQ9jjHctvIlSdbSouHY0GBHx4aqR/FlFVwPJqX0Vr5/JBXRScvyrTCpUs/z6bAFEWgK/+I/90nH\n+Wv4/SUeIHc/AAAA//8DAFBLAQItABQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAAAAAAAAAAAAA\nAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsAAAAA\nAAAAAAAAAAAAHwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAK9Pm9/BAAAA2wAAAA8AAAAA\nAAAAAAAAAAAABwIAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAAAwADALcAAAD1AgAAAAA=\n"));

            V.Rectangle rectangle1 = new V.Rectangle() { Id = "Rectangle 8", Style = "position:absolute;left:678;top:540;width:457;height:71;visibility:visible;mso-wrap-style:square;v-text-anchor:top", OptionalString = "_x0000_s1028", FillColor = "#5f497a", StrokeColor = "#5f497a" };
            rectangle1.SetAttribute(new OpenXmlAttribute("o", "gfxdata", "urn:schemas-microsoft-com:office:office", "UEsDBBQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbHyQz07DMAyH\n70i8Q+QralM4IITa7kDhCAiNB7ASt43WOlEcyvb2pNu4IODoPz9/n1xv9vOkForiPDdwXVagiI23\njocG3rdPxR0oScgWJ8/UwIEENu3lRb09BBKV0ywNjCmFe63FjDSjlD4Q50nv44wpl3HQAc0OB9I3\nVXWrjedEnIq03oC27qjHjympx31un0wiTQLq4bS4shrAECZnMGVTvbD9QSnOhDInjzsyuiBXWQP0\nr4R18jfgnHvJr4nOknrFmJ5xzhraRtHWf3Kkpfz/yGo5S+H73hkquyhdjr3R8m2lj09svwAAAP//\nAwBQSwMEFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsAAABfcmVscy8ucmVsc2zPwWrDMAwG4Ptg72B0\nX5TuUMaI01uh19I+gLGVxCy2jGSy9e1nemrHjpL4P0nD4SetZiPRyNnCruvBUPYcYp4tXC/Htw8w\nWl0ObuVMFm6kcBhfX4Yzra62kC6xqGlKVgtLreUTUf1CyWnHhXKbTCzJ1VbKjMX5LzcTvvf9HuXR\ngPHJNKdgQU5hB+ZyK23zHztFL6w81c5zQp6m6P9TMfB3PtPWFCczVQtB9N4U2rp2HOA44NMz4y8A\nAAD//wMAUEsDBBQABgAIAAAAIQApYTJ8wwAAANsAAAAPAAAAZHJzL2Rvd25yZXYueG1sRE9Na8JA\nEL0X/A/LCL3VTT3UNrqKiJWCUqlVvA7ZaRLNzqTZbYz/3i0UepvH+5zJrHOVaqnxpbCBx0ECijgT\nW3JuYP/5+vAMygdki5UwGbiSh9m0dzfB1MqFP6jdhVzFEPYpGihCqFOtfVaQQz+QmjhyX9I4DBE2\nubYNXmK4q/QwSZ60w5JjQ4E1LQrKzrsfZ+AkR2kP77LdbL4pWZ7mq+3LemXMfb+bj0EF6sK/+M/9\nZuP8Efz+Eg/Q0xsAAAD//wMAUEsBAi0AFAAGAAgAAAAhANvh9svuAAAAhQEAABMAAAAAAAAAAAAA\nAAAAAAAAAFtDb250ZW50X1R5cGVzXS54bWxQSwECLQAUAAYACAAAACEAWvQsW78AAAAVAQAACwAA\nAAAAAAAAAAAAAAAfAQAAX3JlbHMvLnJlbHNQSwECLQAUAAYACAAAACEAKWEyfMMAAADbAAAADwAA\nAAAAAAAAAAAAAAAHAgAAZHJzL2Rvd25yZXYueG1sUEsFBgAAAAADAAMAtwAAAPcCAAAAAA==\n"));

            V.Shapetype shapetype1 = new V.Shapetype() { Id = "_x0000_t32", CoordinateSize = "21600,21600", Oned = true, Filled = false, OptionalNumber = 32, EdgePath = "m,l21600,21600e" };
            V.Path path1 = new V.Path() { AllowFill = false, ShowArrowhead = true, ConnectionPointType = Ovml.ConnectValues.None };
            Ovml.Lock lock1 = new Ovml.Lock() { Extension = V.ExtensionHandlingBehaviorValues.Edit, ShapeType = true };

            shapetype1.Append(path1);
            shapetype1.Append(lock1);
            V.Shape shape1 = new V.Shape() { Id = "AutoShape 9", Style = "position:absolute;left:-83;top:540;width:761;height:0;flip:x;visibility:visible;mso-wrap-style:square", OptionalString = "_x0000_s1029", StrokeColor = "#5f497a", ConnectorType = Ovml.ConnectorValues.Straight, Type = "#_x0000_t32", EncodedPackage = "UEsDBBQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbHyQz07DMAyH\n70i8Q+QralM4IITa7kDhCAiNB7ASt43WOlEcyvb2pNu4IODoPz9/n1xv9vOkForiPDdwXVagiI23\njocG3rdPxR0oScgWJ8/UwIEENu3lRb09BBKV0ywNjCmFe63FjDSjlD4Q50nv44wpl3HQAc0OB9I3\nVXWrjedEnIq03oC27qjHjympx31un0wiTQLq4bS4shrAECZnMGVTvbD9QSnOhDInjzsyuiBXWQP0\nr4R18jfgnHvJr4nOknrFmJ5xzhraRtHWf3Kkpfz/yGo5S+H73hkquyhdjr3R8m2lj09svwAAAP//\nAwBQSwMEFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsAAABfcmVscy8ucmVsc2zPwWrDMAwG4Ptg72B0\nX5TuUMaI01uh19I+gLGVxCy2jGSy9e1nemrHjpL4P0nD4SetZiPRyNnCruvBUPYcYp4tXC/Htw8w\nWl0ObuVMFm6kcBhfX4Yzra62kC6xqGlKVgtLreUTUf1CyWnHhXKbTCzJ1VbKjMX5LzcTvvf9HuXR\ngPHJNKdgQU5hB+ZyK23zHztFL6w81c5zQp6m6P9TMfB3PtPWFCczVQtB9N4U2rp2HOA44NMz4y8A\nAAD//wMAUEsDBBQABgAIAAAAIQDjiYNYxAAAANsAAAAPAAAAZHJzL2Rvd25yZXYueG1sRI9Ba8JA\nEIXvQv/DMkIvUje1UCTNRkQo5NY29QeM2TGJZmfT7GpSf71zKPQ2w3vz3jfZZnKdutIQWs8GnpcJ\nKOLK25ZrA/vv96c1qBCRLXaeycAvBdjkD7MMU+tH/qJrGWslIRxSNNDE2Kdah6ohh2Hpe2LRjn5w\nGGUdam0HHCXcdXqVJK/aYcvS0GBPu4aqc3lxBvyi+NnpA58u061fvVTHz4+iHI15nE/bN1CRpvhv\n/rsurOALrPwiA+j8DgAA//8DAFBLAQItABQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAAAAAAAAA\nAAAAAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsA\nAAAAAAAAAAAAAAAAHwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAOOJg1jEAAAA2wAAAA8A\nAAAAAAAAAAAAAAAABwIAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAAAwADALcAAAD4AgAAAAA=\n" };

            group2.Append(rectangle1);
            group2.Append(shapetype1);
            group2.Append(shape1);

            V.Rectangle rectangle2 = new V.Rectangle() { Id = "Rectangle 10", Style = "position:absolute;left:405;top:11415;width:1033;height:2805;visibility:visible;mso-wrap-style:square;v-text-anchor:top", OptionalString = "_x0000_s1030", Stroked = false };
            rectangle2.SetAttribute(new OpenXmlAttribute("o", "gfxdata", "urn:schemas-microsoft-com:office:office", "UEsDBBQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAW0NvbnRlbnRfVHlwZXNdLnhtbHyQz07DMAyH\n70i8Q+QralM4IITa7kDhCAiNB7ASt43WOlEcyvb2pNu4IODoPz9/n1xv9vOkForiPDdwXVagiI23\njocG3rdPxR0oScgWJ8/UwIEENu3lRb09BBKV0ywNjCmFe63FjDSjlD4Q50nv44wpl3HQAc0OB9I3\nVXWrjedEnIq03oC27qjHjympx31un0wiTQLq4bS4shrAECZnMGVTvbD9QSnOhDInjzsyuiBXWQP0\nr4R18jfgnHvJr4nOknrFmJ5xzhraRtHWf3Kkpfz/yGo5S+H73hkquyhdjr3R8m2lj09svwAAAP//\nAwBQSwMEFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsAAABfcmVscy8ucmVsc2zPwWrDMAwG4Ptg72B0\nX5TuUMaI01uh19I+gLGVxCy2jGSy9e1nemrHjpL4P0nD4SetZiPRyNnCruvBUPYcYp4tXC/Htw8w\nWl0ObuVMFm6kcBhfX4Yzra62kC6xqGlKVgtLreUTUf1CyWnHhXKbTCzJ1VbKjMX5LzcTvvf9HuXR\ngPHJNKdgQU5hB+ZyK23zHztFL6w81c5zQp6m6P9TMfB3PtPWFCczVQtB9N4U2rp2HOA44NMz4y8A\nAAD//wMAUEsDBBQABgAIAAAAIQB2SxQ/wQAAANsAAAAPAAAAZHJzL2Rvd25yZXYueG1sRE9Li8Iw\nEL4L+x/CLHiRNXUPUqtRlgVlD4LPy96GZmyLzSQ0sbb/3giCt/n4nrNYdaYWLTW+sqxgMk5AEOdW\nV1woOJ/WXykIH5A11pZJQU8eVsuPwQIzbe98oPYYChFD2GeooAzBZVL6vCSDfmwdceQutjEYImwK\nqRu8x3BTy+8kmUqDFceGEh39lpRfjzejYHv+d/3IJX2125vLNm1Hqd+QUsPP7mcOIlAX3uKX+0/H\n+TN4/hIPkMsHAAAA//8DAFBLAQItABQABgAIAAAAIQDb4fbL7gAAAIUBAAATAAAAAAAAAAAAAAAA\nAAAAAABbQ29udGVudF9UeXBlc10ueG1sUEsBAi0AFAAGAAgAAAAhAFr0LFu/AAAAFQEAAAsAAAAA\nAAAAAAAAAAAAHwEAAF9yZWxzLy5yZWxzUEsBAi0AFAAGAAgAAAAhAHZLFD/BAAAA2wAAAA8AAAAA\nAAAAAAAAAAAABwIAAGRycy9kb3ducmV2LnhtbFBLBQYAAAAAAwADALcAAAD1AgAAAAA=\n"));

            V.TextBox textBox1 = new V.TextBox() { Style = "layout-flow:vertical;mso-layout-flow-alt:bottom-to-top", Inset = "0,0,0,0" };

            TextBoxContent textBoxContent2 = new TextBoxContent();

            Paragraph paragraph3 = new Paragraph() { RsidParagraphAddition = "002C0D80", RsidRunAdditionDefault = "002C0D80", ParagraphId = "3857EF7C", TextId = "77777777" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId3 = new ParagraphStyleId() { Val = "NoSpacing" };
            Justification justification2 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties3.Append(paragraphStyleId3);
            paragraphProperties3.Append(justification2);

            Run run7 = new Run();
            FieldChar fieldChar4 = new FieldChar() { FieldCharType = FieldCharValues.Begin };

            run7.Append(fieldChar4);

            Run run8 = new Run();
            FieldCode fieldCode2 = new FieldCode() { Space = SpaceProcessingModeValues.Preserve };
            fieldCode2.Text = " PAGE    \\* MERGEFORMAT ";

            run8.Append(fieldCode2);

            Run run9 = new Run();
            FieldChar fieldChar5 = new FieldChar() { FieldCharType = FieldCharValues.Separate };

            run9.Append(fieldChar5);

            Run run10 = new Run();

            RunProperties runProperties4 = new RunProperties();
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();
            NoProof noProof4 = new NoProof();
            Color color3 = new Color() { Val = "BF8F00", ThemeColor = ThemeColorValues.Accent4, ThemeShade = "BF" };
            FontSize fontSize3 = new FontSize() { Val = "52" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "52" };

            runProperties4.Append(bold3);
            runProperties4.Append(boldComplexScript3);
            runProperties4.Append(noProof4);
            runProperties4.Append(color3);
            runProperties4.Append(fontSize3);
            runProperties4.Append(fontSizeComplexScript3);
            Text text2 = new Text();
            text2.Text = "2";

            run10.Append(runProperties4);
            run10.Append(text2);

            Run run11 = new Run();

            RunProperties runProperties5 = new RunProperties();
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();
            NoProof noProof5 = new NoProof();
            Color color4 = new Color() { Val = "BF8F00", ThemeColor = ThemeColorValues.Accent4, ThemeShade = "BF" };
            FontSize fontSize4 = new FontSize() { Val = "52" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "52" };

            runProperties5.Append(bold4);
            runProperties5.Append(boldComplexScript4);
            runProperties5.Append(noProof5);
            runProperties5.Append(color4);
            runProperties5.Append(fontSize4);
            runProperties5.Append(fontSizeComplexScript4);
            FieldChar fieldChar6 = new FieldChar() { FieldCharType = FieldCharValues.End };

            run11.Append(runProperties5);
            run11.Append(fieldChar6);

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run7);
            paragraph3.Append(run8);
            paragraph3.Append(run9);
            paragraph3.Append(run10);
            paragraph3.Append(run11);

            textBoxContent2.Append(paragraph3);

            textBox1.Append(textBoxContent2);

            rectangle2.Append(textBox1);
            Wvml.TextWrap textWrap1 = new Wvml.TextWrap() { AnchorX = Wvml.HorizontalAnchorValues.Margin, AnchorY = Wvml.VerticalAnchorValues.Margin };

            group1.Append(group2);
            group1.Append(rectangle2);
            group1.Append(textWrap1);

            picture1.Append(group1);

            alternateContentFallback1.Append(picture1);

            alternateContent1.Append(alternateContentChoice1);
            alternateContent1.Append(alternateContentFallback1);

            run1.Append(runProperties1);
            run1.Append(alternateContent1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);

            sdtContentBlock1.Append(paragraph1);

            sdtBlock1.Append(sdtProperties1);
            sdtBlock1.Append(sdtContentBlock1);
            return sdtBlock1;
        }
    }
}
