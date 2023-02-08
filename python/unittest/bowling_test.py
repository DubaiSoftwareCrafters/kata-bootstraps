import unittest

_pins = 0


def roll(pins):
    global _pins
    _pins = pins


def score():
    return _pins


class Game:
    def __init__(self):
        self._pins = None

    def roll(self, pins):
        self._pins = pins
        roll(pins)

    def score(self):
        return self._pins
        # return score()


class BowlingTestCase(unittest.TestCase):

    def test_score_is_zero_when_zero_pins_are_knocked(self):
        game = Game()
        game.roll(0)
        self.assertEqual(0, game.score())

    def test_score_is_one_when_one_pin_is_knocked(self):
        game = Game()
        game.roll(1)
        self.assertEqual(1, game.score())
