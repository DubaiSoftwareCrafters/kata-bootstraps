import unittest


def roll(param):
    pass


def score():
    return 0


class BowlingTestCase(unittest.TestCase):

    def test_score_is_zero_when_zero_pins_are_knocked(self):
        roll(0)
        self.assertEqual(score(), 0)

    def test_score_is_one_when_one_pin_is_knocked(self):
        roll(1)
        self.assertEqual(score(), 1)