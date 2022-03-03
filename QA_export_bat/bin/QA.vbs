'// Shell関連の操作を提供するオブジェクトを取得
Set WshShell=Wscript.CreateObject("Wscript.Shell")
'// pageantを秘密鍵認識済みの状態で起動
WshShell.Run("""C:\Program Files\WinSCP\PuTTY\pageant_QA""")

'// 起動してすぐにキー送信すると失敗する可能性があるので、1秒停止
WScript.Sleep( 1000 )

'// 秘密鍵のパスフレーズキーを0.1秒ごとに送信
WshShell.SendKeys("$6{)}YKSjDu6k.Yqi4")
WScript.Sleep( 100 )

WshShell.SendKeys("{TAB}")
WScript.Sleep( 100 )

WshShell.SendKeys("{ENTER}")

'// オブジェクトを解放
sh = null
