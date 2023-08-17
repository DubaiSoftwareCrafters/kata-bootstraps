require 'minitest/autorun'
require 'socket'
require 'timeout'

class IrcTest < Minitest::Test

  def test_connect_invalid_host
    client = IrcClient.new('invalid host', 8888)
    refute client.is_connected
  end

  def test_connect_invalid_port
    client = IrcClient.new('irc.libera.chat', 8888)
    refute client.is_connected
  end

  def test_connection_success
    client = IrcClient.new('irc.libera.chat', 6667)
    assert client.is_connected
  end

  def test_register_user
    client = IrcClient.new('irc.libera.chat', 6667)

    client.register('jon')

    assert client.is_registered
  end

end

class IrcClient

  def initialize(host, port)
    begin
      tcp_socket = make_socket(host, port)
      while (line = tcp_socket.gets)
        if line.include? 'NOTICE'
          @is_connected = true
          break
        end
      end
    rescue SocketError
      @is_connected = false
    rescue Timeout::Error
      @is_connected = false
    end
  end

  def is_connected
    @is_connected
  end

  def is_registered
    # code here
  end

  def register(nick_name)
    # code here
  end

  private

  def make_socket(host, port)
    Timeout.timeout(5) { TCPSocket.new(host, port) }
  end
end