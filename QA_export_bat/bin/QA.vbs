'// Shell�֘A�̑����񋟂���I�u�W�F�N�g���擾
Set WshShell=Wscript.CreateObject("Wscript.Shell")
'// pageant��閧���F���ς݂̏�ԂŋN��
WshShell.Run("""C:\Program Files\WinSCP\PuTTY\pageant_QA""")

'// �N�����Ă����ɃL�[���M����Ǝ��s����\��������̂ŁA1�b��~
WScript.Sleep( 1000 )

'// �閧���̃p�X�t���[�Y�L�[��0.1�b���Ƃɑ��M
WshShell.SendKeys("$6{)}YKSjDu6k.Yqi4")
WScript.Sleep( 100 )

WshShell.SendKeys("{TAB}")
WScript.Sleep( 100 )

WshShell.SendKeys("{ENTER}")

'// �I�u�W�F�N�g�����
sh = null
