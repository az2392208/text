﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleServer.Net
{
    public class ByteArray
    {
        //默认数据长度
        public const int DEFFAULT_SIZE = 1024;
        //初始大小
        private int m_InitSize = 0;
        //缓冲区(真正用于读取的数组)
        public byte[] Bytes;
        //读取位置=开始读的索引
        public int ReadIdx = 0;
        //写入位置=写入完成后的索引
        public int WriteIndex = 0;
        //容量
        private int Capacity = 0;

        //剩余空间(容量减去写入位置)
        public int Remain { get { return Capacity - WriteIndex; } }
        //数据长度(写完后的位置-开始写的时候的位置=数据长度)
        public int Length { get { return WriteIndex - ReadIdx; } }
        /// <summary>
        /// 初始化
        /// </summary>
        public ByteArray()
        {
            Bytes = new byte[DEFFAULT_SIZE];
            Capacity = DEFFAULT_SIZE;
            m_InitSize = DEFFAULT_SIZE;
            ReadIdx = 0;
            WriteIndex = 0;
        }
        /// <summary>
        /// 检测并移动数据
        /// </summary>
        public void CheckAndMoveBytes()
        {
            if (Length < 8)
            {
                return;
            }
        }

        public void MoveBytes()
        {
            if (ReadIdx < 0)
                return;
            //将数组从Readindex开始copy到该数组的0位置copy的长度为length
            Array.Copy(Bytes, ReadIdx, Bytes, 0, Length);
            WriteIndex = Length;
            ReadIdx = 0;
        }
    }
}
