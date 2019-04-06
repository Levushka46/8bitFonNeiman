using _8bitVonNeiman.Common;

namespace _8bitVonNeiman.Cpu {
    public interface ICpuModelOutput {
        /// <summary>
        /// Возвращает память, содержащуюся по переданному адресу.
        /// </summary>
        /// <param name="address">Адрес, по которому запрашивается память.</param>
        /// <returns>Память, содержащаяся по переданному адресу.</returns>
        ExtendedBitArray GetMemory(int address);

        /// <summary>
        /// Устанавливает значение конкретной ячейки памяти.
        /// </summary>
        /// <param name="memory">Значение ячейки памяти.</param>
        /// <param name="address">Адрес ячейки памяти.</param>
        void SetMemory(ExtendedBitArray memory, int address);

        /// <summary>
        /// Вызывается после выполнения команды. Предназначена для обеспечения работы отладчика.
        /// </summary>
        /// <param name="pcl">Новый адрес памяти</param>
        /// <param name="cs">Новый сегмент памяти</param>
        /// <param name="isAutomatic">true если команда выполнена в автоматическом режиме, false - если через "шаг"</param>
        void CommandHasRun(int pcl, int cs, bool isAutomatic);
        
        /// <summary>
        /// Вызывается при обновлении интерфейса. Предназначена для обеспечения автоматического режима выполнения команд.
        /// </summary>
        void UpdateUI();

        /// <summary>
        /// Возвращает память, содержащуюся по переданному адресу внешнего устройства.
        /// </summary>
        /// <param name="address">Адрес внешнего устройства, по которому запрашивается память.</param>
        /// <returns>Память, содержащаяся по переданному адресу.</returns>
        ExtendedBitArray GetExternalMemory(int address);

        /// <summary>
        /// Устанавливает значение конкретной ячейки памяти.
        /// </summary>
        /// <param name="memory">Значение ячейки памяти.</param>
        /// <param name="address">Адрес ячейки памяти внешнего устройства.</param>
        void SetExternalMemory(ExtendedBitArray memory, int address);

        /// <summary>
        /// Возвращает бит памяти, содержащуюся по переданному адресу внешнего устройства.
        /// </summary>
        /// <param name="address">Адрес внешнего устройства, по которому запрашивается память.</param>
        /// <param name="bitIndex">Индекс бита в памяти.</param>
        /// <returns>Память, содержащаяся по переданному адресу.</returns>
        bool GetExternalMemoryBit(int address, int bitIndex);

        /// <summary>
        /// Устанавливает значение конкретного бита ячейки памяти.
        /// </summary>
        /// <param name="value">Значение бита ячейки памяти.</param>
        /// <param name="address">Адрес внешнего устройства, по которому запрашивается память.</param>
        /// <param name="bitIndex">Индекс бита в памяти.</param>
        /// <returns>Память, содержащаяся по переданному адресу.</returns>
        void SetExternalMemoryBit(bool value, int address, int bitIndex);

        /// <summary>
        /// Проверяет имеются ли запросы на прерывание.
        /// </summary>
        bool HasInterruptionRequests();

        /// <summary>
        /// Подтверждает запрос на прерывание и возвращает вектор подтвержденного прерывания.
        /// </summary>
        byte AcknowledgeInterruption();

        /// <summary>
        /// Создает запрос на прерывание.
        /// </summary>
        /// <param name="irq">Вектор прерывания.</param>
        void MakeInterruption(byte irq);

        /// <summary>
        /// Очищает список текущих обрабатываемых прерываний.
        /// </summary>
        void ClearInterruptions();

        /// <summary>
        /// Очищает список текущих обрабатываемых прерываний и список запросов на прерывание.
        /// </summary>
        void Clear();
    }
}
