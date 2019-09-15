using System;
using ObjCRuntime;

namespace QQ.Binding.iOS
{
	[Native]
	public enum QQApiSendResultCode : long
	{
		Qqapisendsucess = 0,
		Qqapiqqnotinstalled = 1,
		Qqapiqqnotsupportapi = 2,
		Qqapimessagetypeinvalid = 3,
		Qqapimessagecontentnull = 4,
		Qqapimessagecontentinvalid = 5,
		Qqapiappnotregisted = 6,
		Qqapiappshareasync = 7,
		QqapiqqnotsupportapiWithErrorshow = 8,
		Qqapimessagearkcontentnull = 9,
		QqapimessageMiniContentnull = 10,
		Qqapisendfaild = -1,
		Qqapisharedestunknown = -2,
		Qqapitimsendfaild = -3,
		Qqapitimnotinstalled = 11,
		Qqapitimnotsupportapi = 12,
		QqapiIncomingParamError = 13,
		QqapiThirdAppGroupErrorAppNotAuthorizied = 14,
		QqapiThirdAppGroupErrorCgiFailed = 15,
		QqapiThirdAppGroupErrorHasBinded = 16,
		QqapiThirdAppGroupErrorNotBinded = 17,
		Qqapiqzonenotsupporttext = 10000,
		Qqapiqzonenotsupportimage = 10001,
		Qqapiversionneedupdate = 10002,
		Timapiversionneedupdate = 10004
	}

	[Native]
	public enum kQQAPICtrlFlag : uint
	{
		ZoneShareOnStart = 1,
		ZoneShareForbid = 2,
		QShare = 4,
		QShareFavorites = 8,
		QShareDataline = 16,
		QShareEnableArk = 32,
		QShareEnableMiniProgram = 64
	}

	[Native]
	public enum ShareDestType : ulong
	{
		Qq = 0,
		Tim
	}

	[Native]
	public enum MiniProgramType : ulong
	{
		Test = 1,
		Online = 3,
		Preview = 4
	}

	[Native]
	public enum QQApiURLTargetType : ulong
	{
		NotSpecified = 0,
		Audio = 1,
		Video = 2,
		News = 3
	}

	[Native]
	public enum QQApiInterfaceReqType : uint
	{
		Getmessagefromqqreqtype = 0,
		Sendmessagetoqqreqtype = 1,
		Showmessagefromqqreqtype = 2,
		Sendmessagearktoqqreqtype = 3,
		SendmessageMiniToqqreqtype = 4
	}

	[Native]
	public enum QQApiInterfaceRespType : uint
	{
		Showmessagefromqqresptype = 0,
		Getmessagefromqqresptype = 1,
		Sendmessagetoqqresptype = 2
	}

	public enum TCOLogLevel
	{
		Disabled = -1,
		Error = 0,
		Warning,
		Info,
		Debug
	}

	public enum TencentAuthShareType : uint
	{
		Qq,
		Tim
	}

	public enum ReponseResult : uint
	{
		Succeed = 0,
		Failed = 1
	}

	public enum UpdateFailType : uint
	{
		Unknown = 1,
		UserCancel,
		Network
	}

	public enum OpenSDKError
	{
		Invalid = -1,
		ErrorUnsupportedAPI = -2,
		ErrorSuccess = 0,
		ErrorUnknown,
		ErrorUserCancel,
		ErrorReLogin,
		ErrorOperationDeny,
		ErrorNetwork,
		ErrorURL,
		ErrorDataParse,
		ErrorParam,
		ErrorConnTimeout,
		ErrorSecurity,
		ErrorIO,
		ErrorServer,
		ErrorWebPage,
		ErrorUserHeadPicLarge = 65536
	}

	[Native]
	public enum TencentAuthorizeState : ulong
	{
		NotAuthorizeState,
		SSOAuthorizeState,
		WebviewAuthorzieState
	}

	[Native]
	public enum TencentAuthMode : ulong
	{
		ClientSideToken,
		ServerSideCode
	}
}
