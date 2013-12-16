package com.junyi00;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.ImageIcon;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.UnsupportedLookAndFeelException;

public class PMRunnerPro extends javax.swing.JFrame {
    
    String dir;
    File BannedFile;
    File BannedIPFile;
    File WhitelistFile;
    File OPFile;
    File PluginFolder;
    File PropertiesFile;
    
    boolean Validated = false;
    
    StreamGobbler oGobbler;
    InputChecker checker;
    
    boolean sRunning = false;
    String sCommand = "";
    boolean sSendNeeded = false;

    public PMRunnerPro() {
        
        //set background image
        URL url = getClass().getResource("/res/bg.png");
        ImageIcon bg = new ImageIcon(url);
        JLabel background = new JLabel(bg);
        setContentPane(background);
        
        //set components (buttons and stuffs)
        initComponents();
        //initMenuBar(); NOT NEEDED YET
    }
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        ServerFinder = new javax.swing.JFileChooser();
        ErrorWindow = new javax.swing.JOptionPane();
        Start = new javax.swing.JButton();
        Exit = new javax.swing.JButton();
        Restart = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        Plugins = new javax.swing.JButton();
        BannedIPs = new javax.swing.JButton();
        OPs = new javax.swing.JButton();
        Whitelist = new javax.swing.JButton();
        Banned = new javax.swing.JButton();
        Properties = new javax.swing.JButton();
        jLabel3 = new javax.swing.JLabel();
        DirBox = new javax.swing.JTextField();
        BrowseDir = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        outputBox = new javax.swing.JTextPane();
        jLabel2 = new javax.swing.JLabel();
        commandBox = new javax.swing.JTextField();
        sendButton = new javax.swing.JButton();

        ServerFinder.setCurrentDirectory(new File(System.getProperty("user.dir")));
        ServerFinder.setDialogTitle("Server Folder");
        ServerFinder.setFileSelectionMode(javax.swing.JFileChooser.DIRECTORIES_ONLY);

        ErrorWindow.setMessage(new String("Current Directory is not a server folder!"));
        ErrorWindow.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        ErrorWindow.setName("Validation Failed"); // NOI18N

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("PMRunnerPro");
        setName("PMRunnerPro"); // NOI18N

        Start.setText("Start");
        Start.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                StartActionPerformed(evt);
            }
        });

        Exit.setText("Exit");
        Exit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                ExitActionPerformed(evt);
            }
        });

        Restart.setText("Restart");
        Restart.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                RestartActionPerformed(evt);
            }
        });

        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/res/icon.png"))); // NOI18N
        jLabel1.setText("jLabel1");

        Plugins.setText("Plugins");
        Plugins.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                PluginsActionPerformed(evt);
            }
        });

        BannedIPs.setText("Banned IPs");
        BannedIPs.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BannedIPsActionPerformed(evt);
            }
        });

        OPs.setText("OPs");
        OPs.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                OPsActionPerformed(evt);
            }
        });

        Whitelist.setText("Whitelist");
        Whitelist.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                WhitelistActionPerformed(evt);
            }
        });

        Banned.setText("Banned");
        Banned.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BannedActionPerformed(evt);
            }
        });

        Properties.setText("Properties");
        Properties.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                PropertiesActionPerformed(evt);
            }
        });

        jLabel3.setText("Directory of PocketMine MP:");

        BrowseDir.setText("Browse");
        BrowseDir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BrowseDirActionPerformed(evt);
            }
        });

        outputBox.setEditable(false);
        jScrollPane1.setViewportView(outputBox);

        jLabel2.setText("Command Input:");

        sendButton.setText("Enter");
        sendButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                sendButtonActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(14, 14, 14)
                .add(jLabel3)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(DirBox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 334, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(BrowseDir, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 80, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
            .add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup()
                .add(26, 26, 26)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(Restart, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 113, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Exit, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 113, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Start, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 113, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .add(109, 109, 109)
                .add(jLabel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 218, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 109, Short.MAX_VALUE)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                    .add(Banned, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(org.jdesktop.layout.GroupLayout.TRAILING, BannedIPs, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 99, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Plugins, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(OPs, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(org.jdesktop.layout.GroupLayout.TRAILING, Whitelist, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 99, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Properties, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE))
                .add(26, 26, 26))
            .add(layout.createSequentialGroup()
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                    .add(layout.createSequentialGroup()
                        .add(jLabel2)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(commandBox)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(sendButton))
                    .add(jScrollPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 623, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(24, 24, 24)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(layout.createSequentialGroup()
                        .add(Banned)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(BannedIPs)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(OPs)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(Whitelist)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(Plugins)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(Properties))
                    .add(jLabel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 218, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(layout.createSequentialGroup()
                        .add(Start, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 64, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .add(24, 24, 24)
                        .add(Exit, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 64, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                        .add(18, 18, 18)
                        .add(Restart, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 64, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))
                .add(24, 24, 24)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel3)
                    .add(DirBox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(BrowseDir))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(jScrollPane1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 218, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel2)
                    .add(commandBox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(sendButton))
                .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
        java.awt.Dimension screenSize = java.awt.Toolkit.getDefaultToolkit().getScreenSize();
        java.awt.Dimension dialogSize = getSize();
        setLocation((screenSize.width-dialogSize.width)/2,(screenSize.height-dialogSize.height)/2);
    }// </editor-fold>//GEN-END:initComponents

   /* public void initMenuBar() {
        System.setProperty("apple.laf.useScreenMenuBar", "true");
               
        
        JMenuBar menubar = new JMenuBar(); //menu bar
        
        JMenu Settings = new JMenu("Settings");
        
        JMenuItem OpenSett = new JMenuItem("Open Settings");
        OpenSett.setActionCommand("Open Settings");
        OpenSett.addActionListener(this);
        Settings.add(OpenSett);
        
        JMenuItem ResetSett = new JMenuItem("Reset Settings");
        ResetSett.setActionCommand("Reset Settings");
        ResetSett.addActionListener(this);
        Settings.add(ResetSett);
        
        menubar.add(Settings);
        this.setJMenuBar(menubar);
    } */
    
    private void validateDir() {
        if (!(new File(dir + "/bin").isDirectory())) Validated = false; //missing php folder
        else if (!(new File(dir + "/bin/php").isFile())) Validated = false; //mising php
        else if (!(new File(dir + "/PocketMine-MP.php").isFile())) Validated = false; //mising main file
        else if (!(new File(dir + "/server.properties").isFile())) Validated = false; //mising properties file
        else if (!(new File(dir + "/src").isDirectory())) Validated = false; //mising source folder
        else if (!(new File(dir + "/start.sh").isFile())) Validated = false; //mising start script
        else Validated = true;
        
        if (Validated == false) {
            JOptionPane.showMessageDialog(null, "Current directory is not a server folder", "Validation Failed", JOptionPane.WARNING_MESSAGE);
        }
        else {
            openFiles();
        }
    }
    
    private void openFiles() {
        BannedFile = new File(dir + "/banned.txt");
        BannedIPFile = new File(dir + "/banned-ips.txt");
        WhitelistFile = new File(dir + "/white-list.txt");
        OPFile = new File(dir + "/ops.txt");
        PluginFolder = new File(dir + "/plugins");
        PropertiesFile = new File(dir + "/server.properties");
    }    
    
    private void StopServer() {
        if (sRunning) {
            sCommand = "stop"; //stop server command
            sSendNeeded = true;
            sRunning = false;
            
            DirBox.setEnabled(true);
            Properties.setEnabled(true);
            Validated = false;
        }
    }
    
    private void StartServer() {
        if (Validated == false) {
            validateDir();
        }
        if (Validated == true && sRunning == false) { //once it passed the previous validation check
            try {
                outputBox.setText("");
                DirBox.setEnabled(false);
                Properties.setEnabled(false);
                
                ProcessBuilder builder = new ProcessBuilder(dir+"/bin/php",  dir+ "/PocketMine-MP.php", "--enable-ansi", "%*");
                builder.redirectErrorStream(true);
                Process process = builder.start();

                oGobbler = new StreamGobbler(process.getInputStream(), process.getOutputStream(), this);

                oGobbler.start();
                sRunning = true;
                
                checker = new InputChecker(process.getOutputStream(), this);
                checker.start();
                
            } catch (IOException ex) {
            }
        }
    }
    
    private void BannedActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BannedActionPerformed
        if (!Validated) {
            JOptionPane.showMessageDialog(null, "Please browse to a server folder", "Error", JOptionPane.WARNING_MESSAGE);
        }
        
        FileReader reader = null;
        try {
            reader = new FileReader(BannedFile);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try { 
            char[] chars = new char[(int) BannedFile.length()];
            reader.read(chars);
            String contents = new String(chars); 
            
            InfoFrame frame = new InfoFrame(contents, "Banned");
            frame.setVisible(true);
        } catch (IOException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
                Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
            }
        } 
    }//GEN-LAST:event_BannedActionPerformed

    private void BrowseDirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BrowseDirActionPerformed
        if (sRunning) {
            return;
        }
        
        int returnVal = ServerFinder.showOpenDialog(this);
        if (returnVal == ServerFinder.APPROVE_OPTION) {
            dir = ServerFinder.getSelectedFile().getAbsolutePath();
            DirBox.setText(dir);
            validateDir();
        }
    }//GEN-LAST:event_BrowseDirActionPerformed

    private void StartActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_StartActionPerformed
        StartServer();
    }//GEN-LAST:event_StartActionPerformed

    private void ExitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_ExitActionPerformed
        StopServer();
    }//GEN-LAST:event_ExitActionPerformed

    private void sendButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_sendButtonActionPerformed
        sCommand = commandBox.getText();
        sSendNeeded = true;
        
        commandBox.setText("");
    }//GEN-LAST:event_sendButtonActionPerformed

    private void BannedIPsActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BannedIPsActionPerformed
        if (!Validated) {
            JOptionPane.showMessageDialog(null, "Please browse to a server folder", "Error", JOptionPane.WARNING_MESSAGE);
        }
        
        FileReader reader = null;
        try {
            reader = new FileReader(BannedIPFile);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try { 
            char[] chars = new char[(int) BannedIPFile.length()];
            reader.read(chars);
            String contents = new String(chars); 
            
            InfoFrame frame = new InfoFrame(contents, "Banned-IP");
            frame.setVisible(true);
        } catch (IOException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
                Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
            }
        } 
    }//GEN-LAST:event_BannedIPsActionPerformed

    private void WhitelistActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_WhitelistActionPerformed
        if (!Validated) {
            JOptionPane.showMessageDialog(null, "Please browse to a server folder", "Error", JOptionPane.WARNING_MESSAGE);
        }
        
        FileReader reader = null;
        try {
            reader = new FileReader(WhitelistFile);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try { 
            char[] chars = new char[(int) WhitelistFile.length()];
            reader.read(chars);
            String contents = new String(chars); 
            
            InfoFrame frame = new InfoFrame(contents, "Whitelist");
            frame.setVisible(true);
        } catch (IOException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
                Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
            }
        } 
    }//GEN-LAST:event_WhitelistActionPerformed

    private void OPsActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_OPsActionPerformed
        if (!Validated) {
            JOptionPane.showMessageDialog(null, "Please browse to a server folder", "Error", JOptionPane.WARNING_MESSAGE);
        }
        
        FileReader reader = null;
        try {
            reader = new FileReader(OPFile);
        } catch (FileNotFoundException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        try { 
            char[] chars = new char[(int) OPFile.length()];
            reader.read(chars);
            String contents = new String(chars); 
            
            InfoFrame frame = new InfoFrame(contents, "OPs");
            frame.setVisible(true);
        } catch (IOException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
                Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
            }
        } 
    }//GEN-LAST:event_OPsActionPerformed

    private void PluginsActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_PluginsActionPerformed
        String plugins = "";
        File[] files = PluginFolder.listFiles();
        
        for (File file : files) {
            String ext = file.getName().substring(file.getName().lastIndexOf(".")+1, file.getName().length());
            if ("php".equals(ext) || "pmf".equals(ext)) {
                plugins += (file.getName().substring(0, file.getName().length()-4) + "\n");
            }
        }
        
        InfoFrame frame = new InfoFrame(plugins, "Plugins");
        frame.setVisible(true);
    }//GEN-LAST:event_PluginsActionPerformed

    private void RestartActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_RestartActionPerformed
        StopServer();
        try {
            Thread.sleep(2000);
        } catch (InterruptedException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        }
        StartServer();
    }//GEN-LAST:event_RestartActionPerformed

    private void PropertiesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_PropertiesActionPerformed
        if (!Validated) {
            JOptionPane.showMessageDialog(null, "Please browse to a server folder", "Error", JOptionPane.WARNING_MESSAGE);
        }
        
        PropertiesFrame pptFrame = new PropertiesFrame(this);
        pptFrame.setVisible(true);
    }//GEN-LAST:event_PropertiesActionPerformed

    public static void main(String args[]) {
        try {
            javax.swing.UIManager.setLookAndFeel(javax.swing.UIManager.getSystemLookAndFeelClassName());
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | UnsupportedLookAndFeelException ex) {
            Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
        }

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new PMRunnerPro().setVisible(true);
            }
        });
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton Banned;
    private javax.swing.JButton BannedIPs;
    private javax.swing.JButton BrowseDir;
    private javax.swing.JTextField DirBox;
    private javax.swing.JOptionPane ErrorWindow;
    private javax.swing.JButton Exit;
    private javax.swing.JButton OPs;
    private javax.swing.JButton Plugins;
    private javax.swing.JButton Properties;
    private javax.swing.JButton Restart;
    private javax.swing.JFileChooser ServerFinder;
    private javax.swing.JButton Start;
    private javax.swing.JButton Whitelist;
    private javax.swing.JTextField commandBox;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextPane outputBox;
    private javax.swing.JButton sendButton;
    // End of variables declaration//GEN-END:variables

    private class InputChecker extends Thread {
        
        PMRunnerPro main;
        OutputStream os;
        
        public InputChecker(OutputStream os, PMRunnerPro main) {
            this.main = main;
            this.os = os;
        }
        
        @Override
        public void run() {
            while(!this.isInterrupted()) {
                try {
                    main.oGobbler.sendCommand(new BufferedWriter(new OutputStreamWriter(os)));
                    Thread.sleep(50);
                } catch (InterruptedException ex) {}
            }
        }
    }
    
    private class StreamGobbler extends Thread {
        InputStream is;
        OutputStream os;
        String line;
        PMRunnerPro main;
        
        BufferedWriter writer;

        public StreamGobbler(InputStream is, OutputStream os, PMRunnerPro main) {
            this.is = is;
            this.os = os;
            this.main = main;
        }
        
        public void sendCommand(BufferedWriter writer) {
            if (main.sSendNeeded) {
                try {
                    writer.write(main.sCommand + "\n");

                    main.sSendNeeded = false;
                    main.sCommand = "";
                } catch (IOException ex) {
                    Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
                }
                finally {
                    try {
                        writer.flush();
                    } catch (IOException ex) {
                        Logger.getLogger(PMRunnerPro.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            }
        }

        @Override
        public void run() {
            try {
                BufferedReader reader = new BufferedReader (new InputStreamReader(is));
                writer = new BufferedWriter(new OutputStreamWriter(os));
                
                sendCommand(writer);
                
                line = reader.readLine();
                while (line != null && ! line.trim().equals("--EOF--")) {
                    
                    main.outputBox.setText(main.outputBox.getText() + (line + "\n"));
                    line = reader.readLine();
                }
                writer.flush();
                
            } catch(IOException ex) {
                System.out.println("NOTE: SERVER ENDED");
                main.sRunning = false;
                checker.interrupt();
            }
            
            System.out.println("NOTE: SERVER ENDED");
            checker.interrupt();
            main.sRunning = false;
        }
    }
}
