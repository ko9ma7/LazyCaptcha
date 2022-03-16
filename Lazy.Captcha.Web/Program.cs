using Lazy.Captcha.Core;
using Lazy.Captcha.Core.Generator;
using Lazy.Captcha.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


// �ڴ�洢�� ����appsettings.json����
builder.Services.AddCaptcha(builder.Configuration, options =>
{
    // �Զ�������
    options.ImageOption.FontSize = 28;
    options.ImageOption.FontFamily = ResourceFontFamilysFinder.Find("KG HAPPY");
});
// �������������룬���ע�ͼ��ɡ�
//builder.Services.Add(ServiceDescriptor.Scoped<ICaptcha, RandomCaptcha>());

// ���ʹ��redis���棬��������
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetConnectionString("RedisCache");
//    options.InstanceName = "captcha:";
//});


// -----------------------------------------------------------------------------
// ȫ�����ò��������ڴ�������
//builder.Services.AddCaptcha(builder.Configuration, option =>
//{
//    option.CaptchaType = CaptchaType.WORD; // ��֤������
//    option.CodeLength = 6; // ��֤�볤��, Ҫ����CaptchaType���ú�.  ������Ϊ�������ʽʱ�����ȴ�������ĸ���
//    option.ExpirySeconds = 30; // ��֤�����ʱ��
//    option.IgnoreCase = true; // �Ƚ�ʱ�Ƿ���Դ�Сд
//    option.StoreageKeyPrefix = ""; // �洢��ǰ׺

//    option.ImageOption.Animation = true; // �Ƿ����ö���
//    option.ImageOption.FrameDelay = 30; // ÿ֡�ӳ�,Animation=trueʱ��Ч, Ĭ��30

//    option.ImageOption.Width = 150; // ��֤����
//    option.ImageOption.Height = 50; // ��֤��߶�
//    option.ImageOption.BackgroundColor = SixLabors.ImageSharp.Color.White; // ��֤�뱳��ɫ

//    option.ImageOption.BubbleCount = 2; // ��������
//    option.ImageOption.BubbleMinRadius = 5; // ������С�뾶
//    option.ImageOption.BubbleMaxRadius = 15; // �������뾶
//    option.ImageOption.BubbleThickness = 1; // ���ݱ��غ��

//    option.ImageOption.InterferenceLineCount = 2; // ����������

//    option.ImageOption.FontSize = 36; // �����С
//    option.ImageOption.FontFamily = DefaultFontFamilys.Instance.Actionj; // ���壬����ʹ��kaiti�������ַ��ɸ���ϲ�����ã����ܲ���ת�ַ�����ֻ��Ʋ������������
//});

// ע�⣺ appsettings.json���úʹ�������ͬʱ����ʱ���������ûḲ��appsettings.json���á�

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();