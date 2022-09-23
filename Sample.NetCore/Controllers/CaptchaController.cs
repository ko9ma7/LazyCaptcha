using Lazy.Captcha.Core;
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
            // ���ܻ��жദ��֤���ҹ���ʱ�䲻һ�����ɴ��ڶ�����������Ĭ�����á���https://gitee.com/pojianbing/lazy-captcha/issues/I4XHGM��
            //var info = _captcha.Generate(id,120);
            var stream = new MemoryStream(info.Bytes);
            return File(stream, "image/gif");
        }

        /// <summary>
        /// ��ʾʱʹ��HttpGet���η��㣬����������ش���
        /// </summary>
        [HttpGet("validate")]
        public bool Validate(string id, string code)
        {
            return _captcha.Validate(id, code);
        }

        /// <summary>
        /// һ����֤����У�飨https://gitee.com/pojianbing/lazy-captcha/issues/I4XHGM��
        /// ��ʾʱʹ��HttpGet���η��㣬����������ش���
        /// </summary>
        [HttpGet("validate2")]
        public bool Validate2(string id, string code)
        {
            return _captcha.Validate(id, code, false);
        }
    }
}