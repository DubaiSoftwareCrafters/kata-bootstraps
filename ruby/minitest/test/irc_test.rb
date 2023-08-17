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

    assert client.register('CCClient')
  end

  def test_existing_nickname
    client = IrcClient.new('irc.libera.chat', 6667)

    refute client.register('jon')
  end

  def test_list_channels
    client = IrcClient.new('irc.libera.chat', 6667)
    client.register('CCClient_listing')

    assert client.list_channels > 0
  end

end

class IrcClient

  def initialize(host, port)
    begin
      @tcp_socket = make_socket(host, port)
      while (line = @tcp_socket.gets)
        puts line
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

  def register(nick_name)
    send_message "NICK #{nick_name}"
    send_message "USER guest 0 * :Coding Challenges Client"

    while (line = @tcp_socket.gets)
      if nickname_already_in_use(line)
        return false
      end
      if user_registered(line)
        return true
      end
    end
  end

  def make_socket(host, port)
    Timeout.timeout(5) { TCPSocket.new(host, port) }
  end

  def list_channels
    send_message "list"
    lines = []
    while (line = @tcp_socket.gets)
      lines.append line
      if line.include? ':End of /LIST'
        return lines.length
      end
    end
  end

  private

  def send_message(string)
    @tcp_socket.puts string
  end

  def user_registered(line)
    line.include? ':End of /MOTD command.'
  end

  def nickname_already_in_use(line)
    line.include? ':Nickname is already in use.'
  end
end