namespace _8bitVonNeiman.Common {

    public static class Constants {
        /// Количество бит в полном адресе (дальнем)
        public const int FarAddressBitsCount = 10;

        /// Количество бит в укороченном адресе (ближнем)
        public const int ShortAddressBitsCount = 8;

        /// Начальный адрес, с которого начинает записываться программа,
        /// и в который по умолчанию устанавливается процессор при сбросею
        public const int StartAddress = 16;

        /// Адрес ячейки, в которой хранится начальный адрес.
        public const int ResetVectorAddress = 0;

        /// Размер слова в архитектуре процессора
        public const int WordSize = 8;
    }
}
