package mainWindow;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.util.*;

import java.net.Socket;
import java.net.SocketException;
import java.io.*;

public class Main extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		try{
	        Socket socket = new Socket("166.111.180.60", 8000);
	        // 向服务端程序发送数据
	        OutputStream ops  = socket.getOutputStream();    
	        
	        OutputStreamWriter opsw = new OutputStreamWriter(ops);
	        BufferedWriter bw = new BufferedWriter(opsw);
	        PrintWriter pw = new PrintWriter(bw, true);
	        
	        pw.print("2012011514_net2014");
	        pw.flush();
	        //pw.close();
	        //bw.write("2012011514_net2014");
	        //bw.flush();
	        
	        // 从服务端程序接收数据
	        InputStream ips = socket.getInputStream();
	        InputStreamReader ipsr = new InputStreamReader(ips);
	        char[] buffer = new char[2048];
	        int len;
	        int i=0;
	        StringBuffer store = new StringBuffer();
	        len = ipsr.read(buffer);
	        while(len != -1)
	        {
	        	store.append(buffer);
	        	len = ipsr.read(buffer);
	        }
	        
	        socket.close();
		}
		catch(IOException e){
			e.printStackTrace();
		}
	        
	        
		//System.out.println(new Date());
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Main frame = new Main();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Main() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 437);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);
		
		JButton btnNewButton = new JButton("New button");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				btnNewButton.setText("hello, world");
				
			}
		});
		contentPane.add(btnNewButton, BorderLayout.CENTER);
		
		JButton btnShowkun = new JButton("showkun");
		contentPane.add(btnShowkun, BorderLayout.EAST);
	}

}
