#для генерации файла поменять string на название ВУ + .bin

import pickle
import random

string = 'GraphicDisplay.bin'

class Bin:
    ed = string
    StrEd = ''

    def f(self):
        for s in self.ed:
            self.StrEd += self.ed + str(random.random())

bin = Bin()
bin.f()

with open(string, 'wb') as openFile:
    pickle.dump(bin, openFile)
