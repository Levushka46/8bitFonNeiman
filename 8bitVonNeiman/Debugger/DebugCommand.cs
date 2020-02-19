using _8bitVonNeiman.Common;
using System.Linq;

namespace _8bitVonNeiman.Debug {
    public class DebugCommand {
        public readonly int Address;
        public readonly string Name;
        public readonly string Argument;
        public readonly string Command;
        public bool HasBreakpoint = false;
        public bool Selected = false;

        private ExtendedBitArray _lowCommand;
        private ExtendedBitArray _highCommand;

        public DebugCommand(ExtendedBitArray lowCommand, ExtendedBitArray highCommand, int address) {
            Address = address;
            _lowCommand = lowCommand;
            _highCommand = highCommand;

            Command = new string(highCommand.ToBinString().ToArray()) + ' ' + new string(lowCommand.ToBinString().ToArray());
            Name = GetCommandName(lowCommand, highCommand);
            Argument = GetCommandArgument(lowCommand, highCommand);
        }

        private string GetCommandName(ExtendedBitArray lowCommand, ExtendedBitArray highCommand) {
            var highBin = highCommand.ToBinString();
            var highHex = highCommand.ToHexString();
            var lowBin = lowCommand.ToBinString();
            var lowHex = lowCommand.ToHexString();

            // Безадресные
            if (highHex == "00") {
                if (lowHex == "00") {
                    return "HLT";
                }
                if (lowHex == "01") {
                    return "NOP";
                }
                if (lowHex == "02") {
                    return "RET";
                }
                if (lowHex == "03") {
                    return "IRET";
                }
                if (lowHex == "04") {
                    return "EI";
                }
                if (lowHex == "05") {
                    return "DI";
                }
                if (lowHex == "06") {
                    return "RR";
                }
                if (lowHex == "07") {
                    return "RL";
                }
                if (lowHex == "08") {
                    return "RRC";
                }
                if (lowHex == "09") {
                    return "RLC";
                }
                if (lowHex == "0A") {
                    return "HLT";
                }
                if (lowHex == "0B") {
                    return "INCA";
                }
                if (lowHex == "0C") {
                    return "DECA";
                }
                if (lowHex == "0D") {
                    return "SWAPA";
                }
                if (lowHex == "0E") {
                    return "DAA";
                }
                if (lowHex == "0F") {
                    return "DSA";
                }
                if (lowHex == "10") {
                    return "IN";
                }
                if (lowHex == "11") {
                    return "OUT";
                }
                if (lowHex == "12") {
                    return "ES";
                }
                if (lowHex == "13") {
                    return "MOVASR";
                }
                if (lowHex == "14") {
                    return "MOVSRA";
                }
                if (lowHex == "15") {
                    return "NOTA";
                }
                if (lowHex == "16"){
                    return "MOVAPSW";
                }
            }

            // DJRNZ
            if (highBin.StartsWith("0001")) {
                return "DJRNZ";
            }

            // операторы перехода
            if (highBin.StartsWith("001")) {
                if (highBin.StartsWith("001100")) {
                    return "JZ";
                }
                if (highBin.StartsWith("001000")) {
                    return "JNZ";
                }
                if (highBin.StartsWith("001101")) {
                    return "JC";
                }
                if (highBin.StartsWith("001001")) {
                    return "JNC";
                }
                if (highBin.StartsWith("001110")) {
                    return "JN";
                }
                if (highBin.StartsWith("001010")) {
                    return "JNN";
                }
                if (highBin.StartsWith("001111")) {
                    return "JO";
                }
                if (highBin.StartsWith("001011")) {
                    return "JNO";
                }
            }

            // Операторы передачи управления
            if (highBin.StartsWith("0100")) {
                if (highBin.StartsWith("010000")) {
                    return "JMP";
                }
                if (highBin.StartsWith("010010")) {
                    return "CALL";
                }
                if (highBin.StartsWith("010011")) {
                    return "INT";
                }
            }

            // Регистровые команды
            if (highBin.StartsWith("0101") || highBin.StartsWith("1111")) {
                if (highHex[1] == 'F') {
                    return "MOV";
                }
                if (highHex[1] == 'D') {
                    return "POP";
                }
                if (highHex[1] == 'A') {
                    return "WR";
                }
                if (highHex[1] == '0') {
                    return "NOT";
                }
                if (highHex[1] == '1') {
                    return "ADD";
                }
                if (highHex[1] == '2') {
                    return "SUB";
                }
                if (highHex[1] == '3') {
                    return "MUL";
                }
                if (highHex[1] == '4') {
                    return "DIV";
                }
                if (highHex[1] == '5') {
                    return "AND";
                }
                if (highHex[1] == '6') {
                    return "OR";
                }
                if (highHex[1] == '7') {
                    return "XOR";
                }
                if (highHex[1] == '8') {
                    return "CMP";
                }
                if (highHex[1] == '9') {
                    return "RD";
                }
                if (highHex[1] == 'B') {
                    return "INC";
                }
                if (highHex[1] == 'C') {
                    return "DEC";
                }
                if (highHex[1] == 'E') {
                    return "PUSH";
                }
                if (highHex == "F0") {
                    return "ADC";
                }
                if (highHex == "F1") {
                    return "SUBB";
                }
            }

            // ОЗУ
            if (highBin.StartsWith("011")) {
                if (highHex[1] == 'A') {
                    return "WR";
                }
                if (highHex[1] == '0') {
                    return "NOT";
                }
                if (highHex[1] == '1') {
                    return "ADD";
                }
                if (highHex[1] == '2') {
                    return "SUB";
                }
                if (highHex[1] == '3') {
                    return "MUL";
                }
                if (highHex[1] == '4') {
                    return "DIV";
                }
                if (highHex[1] == '5') {
                    return "AND";
                }
                if (highHex[1] == '6') {
                    return "OR";
                }
                if (highHex[1] == '7') {
                    return "XOR";
                }
                if (highHex[1] == '8') {
                    return "CMP";
                }
                if (highHex[1] == '9') {
                    return "RD";
                }
                if (highHex[1] == 'B') {
                    return "INC";
                }
                if (highHex[1] == 'C') {
                    return "DEC";
                }
                if (highHex[1] == 'D') {
                    return "ADC";
                }
                if (highHex[1] == 'E') {
                    return "SUBB";
                }
                if (highHex[1] == 'F') {
                    return "XCH";
                }
            }

            // Битовые команды
            if (highBin.StartsWith("10000")) {
                return "CB";
            }
            if (highBin.StartsWith("10001")) {
                return "SB";
            }
            if (highBin.StartsWith("10010")) {
                return "SBC";
            }
            if (highBin.StartsWith("10011")) {
                return "SBS";
            }
            if (highBin.StartsWith("10100") && lowBin[0] == '1') {
                return "CBI";
            }
            if (highBin.StartsWith("10101") && lowBin[0] == '0') {
                return "SBI";
            }
            if (highBin.StartsWith("10101") && lowBin[0] == '1') {
                return "NBI";
            }
            if (highBin.StartsWith("10110") && lowBin[0] == '0') {
                return "SBIC";
            }
            if (highBin.StartsWith("10110") && lowBin[0] == '1') {
                return "SBIS";
            }
            if (highBin.StartsWith("10111") && lowBin[0] == '0') {
                return "SBISC";
            }

            // Команды ввода-вывода
            if (highBin == "11000000") {
                return "IN";
            }
            if (highBin == "11000001") {
                return "OUT";
            }

            return "ERROR";
        }

        private string GetCommandArgument(ExtendedBitArray lowCommand, ExtendedBitArray highCommand) {
            var highBin = highCommand.ToBinString();
            var highHex = highCommand.ToHexString();
            var lowBin = lowCommand.ToBinString();
            var lowHex = lowCommand.ToHexString();

            // Безадресные
            if (highHex == "00") {
                return null;
            }

            // DJRNZ
            if (highBin.StartsWith("0001")) {
                int register = (highCommand.NumValue() >> 2) & 0b11;
                string segment = (highCommand.NumValue() & 0b11).ToString();
                string address = lowCommand.ToHexString();
                return string.Format("R{0}, 0x{1}{2}", register.ToString(), segment, address);
            }

            // операторы перехода
            if (highBin.StartsWith("001")) {
                string segment = (highCommand.NumValue() & 0b11).ToString();
                string address = lowCommand.ToHexString();
                return string.Format("0x{0}{1}", segment, address);
            }

            // Операторы передачи управления
            if (highBin.StartsWith("0100")) {
                string segment = (highCommand.NumValue() & 0b11).ToString();
                string address = lowCommand.ToHexString();
                return string.Format("0x{0}{1}", segment, address);
            }

            // Регистровые команды
            //Прямая - 000
            //@R     - 100
            //@R+    - 001
            //+@R    - 101
            //@R-    - 011
            //-@R    - 111
            // 041537
            if (highBin.StartsWith("0101"))
            {
                //MOV R{0}, R{1}
                if (highBin.StartsWith("01011111"))
                {
                    int registerSource = lowCommand.NumValue() >> 4;
                    int registerDestination = lowCommand.NumValue() & 0x0F;
                    string registerFormat = "R{0}, R{1}";
                    return string.Format(registerFormat, registerDestination, registerSource);
                }
                else
                {
                    int addressType = lowCommand.NumValue() >> 4;
                    int register = lowCommand.NumValue() & 0x0F;
                    string registerFormat = "R{0}";
                    switch (addressType)
                    {
                        case 0:
                            registerFormat = "R{0}";
                            break;
                        case 1:
                            registerFormat = "@R{0}";
                            break;
                        case 4:
                            registerFormat = "@R{0}+";
                            break;
                        case 5:
                            registerFormat = "+@R{0}";
                            break;
                        case 6:
                            registerFormat = "@R{0}-";
                            break;
                        case 7:
                            registerFormat = "-@R{0}";
                            break;
                    }
                    return string.Format(registerFormat, register);
                }
            }

            // ОЗУ
            if (highBin.StartsWith("011"))
            {
            //Dec: lowCommand.NumValue().ToString(); 
            //Hex: lowHex.ToString();
                string addressOrConst = lowHex.ToString();
                bool isConst = highBin.StartsWith("0111");
                return (isConst ? "#0x" : "") + addressOrConst;
            }

            // Битовые команды
            if (highBin.StartsWith("100")) {
                string bit = (highCommand.NumValue() & 0b111).ToString();
                string address = lowCommand.NumValue().ToString();
                return string.Format("{0}, {1}", address, bit);
            }
            if (highBin.StartsWith("101")) {
                string bit = (highCommand.NumValue() & 0b111).ToString();
                ExtendedBitArray addr = new ExtendedBitArray(lowCommand);
                addr.And(new ExtendedBitArray("0111111"));
                string address = addr.NumValue().ToString();
                return string.Format("{0}, {1}", address, bit);
            }

            // Команды ввода-вывода
            if (highBin == "11000000" || highBin == "11000001") {
                string address = lowCommand.NumValue().ToString();
                return address;
            }

            return null;
        }
    }
}
