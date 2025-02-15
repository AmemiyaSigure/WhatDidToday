﻿using Native.Csharp.Sdk.Cqp.Enum;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.Sdk.Cqp.EventArgs
{
	/// <summary>
	/// 提供用于描述酷Q私聊消息事件参数的类
	/// <para/>
	/// Type: 21
	/// </summary>
	public class CQPrivateMessageEventArgs : CQEventEventArgs
	{
		#region --属性--
		/// <summary>
		/// 获取当前事件的消息子类型
		/// </summary>
		public CQPrviateMessageType SubType { get; private set; }

		/// <summary>
		/// 获取当前事件的来源QQ
		/// </summary>
		public QQ FromQQ { get; private set; }

		/// <summary>
		/// 获取当前事件的消息内容
		/// </summary>
		public QQMessage Message { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="CQPrivateMessageEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="id">事件id</param>
		/// <param name="type">事件类型</param>
		/// <param name="name">事件名称</param>
		/// <param name="function">事件函数名</param>
		/// <param name="priority">事件优先级</param>
		/// <param name="subType">消息子类型</param>
		/// <param name="msgId">消息ID</param>
		/// <param name="fromQQ">来源QQ</param>
		/// <param name="msg">消息内容</param>
		/// <param name="isRegex">是否为正则消息</param>
		/// <param name="api">接口API实例</param>
		public CQPrivateMessageEventArgs (int id, int type, string name, string function, uint priority, int subType, int msgId, long fromQQ, string msg, bool isRegex, CQApi api)
			: base (id, type, name, function, priority)
		{
			this.SubType = (CQPrviateMessageType)subType;
			this.FromQQ = new QQ (api, fromQQ);
			this.Message = new QQMessage (api, msgId, msg, isRegex);
		}
		#endregion

		#region --公开函数--
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();
			builder.AppendLine (string.Format ("ID: {0}", this.Id));
			builder.AppendLine (string.Format ("类型: {0}({1})", this.Type, (int)this.Type));
			builder.AppendLine (string.Format ("名称: {0}", this.Name));
			builder.AppendLine (string.Format ("函数: {0}", this.Function));
			builder.AppendLine (string.Format ("优先级: {0}", this.Priority));
			builder.AppendLine (string.Format ("子类型: {0}({1})", this.SubType, (int)this.SubType));
			builder.AppendLine (string.Format ("来源QQ: {0}", this.FromQQ.Id));
			builder.AppendLine (string.Format ("消息ID: {0}", this.Message.Id));
			builder.AppendLine (string.Format ("是否正则消息: {0}", this.Message.IsRegexMessage));
			if (this.Message.IsRegexMessage)
			{
				builder.Append ("解析结果: ");
				foreach (KeyValuePair<string, string> keyValue in this.Message.PairsMessage)
				{
					builder.AppendFormat ("{0}-{1}, ", keyValue.Key, keyValue.Value);
				}
				builder.Remove (builder.Length - 2, 2); // 删除最后的符号和空格
			}
			else
			{
				builder.AppendFormat ("消息内容: {0}", this.Message.OriginalMessage);
			}
			return builder.ToString ();
		}
		#endregion
	}
}
