using OpenQA.Selenium;

namespace Phlex.Core.TestInfrastructure.Selenium
{
    public class With
    {
        public static By ClassName(string className)
        {
            return By.ClassName(className);
        }

        public static By CssSelector(string cssSelectorToFind)
        {
            return By.CssSelector(cssSelectorToFind);
        }

        public static By Id(string idToFind)
        {
            return By.Id(idToFind);
        }

        public static By Name(string nameToFind)
        {
            return By.Name(nameToFind);
        }

        public static By LinkText(string linkTextToFind)
        {
            return By.LinkText(linkTextToFind);
        }

        public static By PartialLinkText(string partialLinkTextToFind)
        {
            return By.PartialLinkText(partialLinkTextToFind);
        }

        public static By TagAndAttribute(string tag, string attribute, string value)
        {
            return By.CssSelector($"{tag}[{attribute}=\"{value}\"]");
        }

        public static By TagAndIdAndText(string tag, string id, string innerText)
        {
            var xpath = $"//{tag}[@id=\"{id}\" and contains(text(), \"{innerText}\")]";
            return By.XPath(xpath);
        }

        public static By TagAndClassAndText(string tag, string className, string innerText)
        {
            var xpath = $"//{tag}[@class=\"{className}\" and text()=\"{innerText}\"]";
            return By.XPath(xpath);
        }

        public static By TagAndText(string tag, string innerText)
        {
            return By.XPath($".//{tag}[text()=\"{innerText}\"]");
        }

        public static By PartialTagAndText(string tag, string innerText)
        {
            return By.XPath($".//{tag}[text()[contains(., \"{innerText}\")]]");
        }

        public static By TagName(string tagNameToFind)
        {
            return By.TagName(tagNameToFind);
        }

        public static By XPath(string xpathToFind)
        {
            return By.XPath(xpathToFind);
        }

        public static By SvgTagName(string svgTag)
        {
            return By.XPath($".//*[name()='{svgTag}']");
        }

        public static By SvgTagNameAndAttribute(string svgTag, string attributeName, string attributeValue)
        {
            return By.XPath($".//*[name()='{svgTag}' and @{attributeName}='{attributeValue}']");
        }

        public static By SvgTagNameAndAttribute(string svgTag, string attributeName)
        {
            return By.XPath($".//*[name()='{svgTag}' and @{attributeName}]");
        }

        public static By InputValue(string value)
        {
            return By.CssSelector($"input[value=\"{value}\"]");
        }

        public static By TagWithAnyText(string tagName)
        {
            return By.XPath($".//{tagName}[text()]");
        }

        public static By Closest(string xpathToFind)
        {
            return By.XPath($"{xpathToFind}/ancestor-or-self::dl");
        }

        public static By PartialId(string idPartial)
        {
            return By.XPath($"//*[contains(@id, '{idPartial}')]");
        }
    }
}