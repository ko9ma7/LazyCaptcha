using Lazy.Captcha.Core;
using Lazy.Captcha.Core.Generator;
using Microsoft.AspNetCore.Mvc;

namespace Sample.NetCore.Controllers
{
    [Route("captcha")]
    [ApiController]
    public class CaptchaController : Controller
    {
        private readonly ICaptcha _captcha;

        public CaptchaController(ICaptcha captcha)
        {
            _captcha = captcha;
        }

        [HttpGet]
        public IActionResult Captcha(string id)
        {
            var info = _captcha.Generate(id);
            // 可能会有多处验证码且过期时间不一样，可传第二个参数覆盖默认配置。（https://gitee.com/pojianbing/lazy-captcha/issues/I4XHGM）
            //var info = _captcha.Generate(id,120);
            var stream = new MemoryStream(info.Bytes);
            return File(stream, "image/gif");
        }

        /// <summary>
        /// 演示时使用HttpGet传参方便，这里仅做返回处理
        /// </summary>
        [HttpGet("validate")]
        public bool Validate(string id, string code)
        {
            return _captcha.Validate(id, code);
        }

        /// <summary>
        /// 一个验证码多次校验（https://gitee.com/pojianbing/lazy-captcha/issues/I4XHGM）
        /// 演示时使用HttpGet传参方便，这里仅做返回处理
        /// </summary>
        [HttpGet("validate2")]
        public bool Validate2(string id, string code)
        {
            return _captcha.Validate(id, code, false);
        }


        /// <summary>
        /// 请使用注入方式，这里仅是方便前端动态展示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        [HttpGet("dynamic")]
        public IActionResult DynamicCaptcha(string id, string type, string font)
        {
            var captchaService = CaptchaServiceBuilder
              .New()
              .Width(98)
              .Height(35)
              .FontSize(26)
              .CaptchaType(Enum.Parse<CaptchaType>(type))
              .FontFamily(DefaultFontFamilys.Instance.GetFontFamily(font))
              .InterferenceLineCount(2)
              .Animation(false)
              .Build();
            var info = captchaService.Generate(id);
            var stream = new MemoryStream(info.Bytes);
            return File(stream, "image/gif");
        }
    }
}