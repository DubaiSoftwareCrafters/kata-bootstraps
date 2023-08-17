# frozen_string_literal: true
require 'minitest/autorun'

class ParserTest < Minitest::Test

  def parse_channel(line)
    line.partition('#').last.split(" ").first
  end

  def test_channel_name
    line = ":lithium.libera.chat 322 CCClient #yabause 12 :Yabause, A Beautiful And Under-rated Saturn Emulator | 0.9.15 has been released! | This is COOL | Our new home!"

    assert_equal  "yabause", parse_channel(line)
    end

  def parse_channels(lines)
    lines.map {|line| parse_channel line}
  end

  def test_channel_names
    line = ":lithium.libera.chat 322 CCClient #yabause 12 :Yabause, A Beautiful And Under-rated Saturn Emulator | 0.9.15 has been released! | This is COOL | Our new home!"

    lines = [line,line]

    assert_equal  ["yabause","yabause"], parse_channels(lines)
  end

end
