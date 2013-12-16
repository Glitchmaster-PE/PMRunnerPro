package com.junyi00;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JCheckBox;
import javax.swing.JOptionPane;
import javax.swing.JTextField;


public class PropertiesFrame extends javax.swing.JFrame {
    Map<String, JTextField> PropertiesText = new HashMap<>();
    Map<String, JCheckBox> PropertiesCheck = new HashMap<>();
    PMRunnerPro main;
    
    public PropertiesFrame(PMRunnerPro main) {
        this.main = main;
        
        initComponents();
        loadProperties();
    }
    
    private void initMap() {
        PropertiesText.put("server-name", SNbox);
        PropertiesText.put("description", Dbox);
        PropertiesText.put("motd", MOTDbox);
        PropertiesText.put("server-ip", IPbox);
        PropertiesText.put("server-port", SPbox);
        PropertiesCheck.put("white-list", Wbox);
        PropertiesText.put("spawn-protection", SPbox);
        PropertiesText.put("max-players", MPbox);
        PropertiesText.put("gamemode", Gbox);
        PropertiesCheck.put("hardcore", Hbox);
        PropertiesCheck.put("pvp", PVPbox);
        PropertiesText.put("level-name", LNbox);
        PropertiesText.put("level-type", LTbox);
        PropertiesCheck.put("enable-query", Qbox);
        PropertiesCheck.put("enable-rcon", RCONbox);
        PropertiesText.put("rcon.password", RCONPbox);
    }
    
    private String getProperties() {
        FileReader reader;
        String ppts = null;
        
        try {
            reader = new FileReader(main.PropertiesFile);
        } catch (FileNotFoundException ex) {
            return null;
        }
        
        try { 
            char[] chars = new char[(int) main.PropertiesFile.length()];
            reader.read(chars);
            ppts = new String(chars); 
            
        } catch (IOException ex) {
            return null;
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
                return null;
            }
        } 
        
        return ppts;
    }
    
    public void loadProperties() {
        initMap();
        
        String ppts = getProperties();
        
        if (ppts == null) {
            JOptionPane.showMessageDialog(null, "Reading of properties failed!", "Error", JOptionPane.WARNING_MESSAGE);
            this.setVisible(false);
        }
        
        for (String ppt : ppts.split("\n")) {
            
            if(ppt.contains("=")) {
                String key = ppt.split("=")[0];
                if (PropertiesText.containsKey(key)) {
                    JTextField textfield = PropertiesText.get(key);
                    if (ppt.split("=").length == 2) {
                        String value = ppt.split("=")[1];
                        textfield.setText(value);
                    }
                    else {
                        textfield.setText("");
                    }
                }
                else if (PropertiesCheck.containsKey(key)) {
                    JCheckBox checkbox = PropertiesCheck.get(key);
                    if ("on".equals(ppt.split("=")[1])) {
                        checkbox.setSelected(true);
                    }
                    else {
                        checkbox.setSelected(false);
                    }
                }
            }
        }
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabel1 = new javax.swing.JLabel();
        SNbox = new javax.swing.JTextField();
        jLabel2 = new javax.swing.JLabel();
        Dbox = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        MOTDbox = new javax.swing.JTextField();
        jLabel4 = new javax.swing.JLabel();
        IPbox = new javax.swing.JTextField();
        jLabel5 = new javax.swing.JLabel();
        IPbox1 = new javax.swing.JTextField();
        jLabel6 = new javax.swing.JLabel();
        Wbox = new javax.swing.JCheckBox();
        jLabel7 = new javax.swing.JLabel();
        SPbox = new javax.swing.JTextField();
        jLabel8 = new javax.swing.JLabel();
        MPbox = new javax.swing.JTextField();
        jLabel9 = new javax.swing.JLabel();
        Gbox = new javax.swing.JTextField();
        jLabel10 = new javax.swing.JLabel();
        Hbox = new javax.swing.JCheckBox();
        jLabel11 = new javax.swing.JLabel();
        PVPbox = new javax.swing.JCheckBox();
        jLabel12 = new javax.swing.JLabel();
        LNbox = new javax.swing.JTextField();
        jLabel13 = new javax.swing.JLabel();
        LTbox = new javax.swing.JTextField();
        jLabel14 = new javax.swing.JLabel();
        Qbox = new javax.swing.JCheckBox();
        jLabel15 = new javax.swing.JLabel();
        RCONbox = new javax.swing.JCheckBox();
        jLabel16 = new javax.swing.JLabel();
        RCONPbox = new javax.swing.JTextField();
        SaveButton = new javax.swing.JButton();
        CancelButton = new javax.swing.JButton();

        setTitle("Properties");

        jLabel1.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel1.setText("Server Name:");

        jLabel2.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel2.setText("Description:");

        jLabel3.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel3.setText("MOTD:");

        jLabel4.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel4.setText("IP:");

        jLabel5.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel5.setText("Whitelist:");

        jLabel6.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel6.setText("Port:");

        Wbox.setText("True");

        jLabel7.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel7.setText("Spawn Protection:");

        jLabel8.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel8.setText("Max Players:");

        jLabel9.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel9.setText("Gamemode:");

        jLabel10.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel10.setText("Hardcore:");

        Hbox.setText("True");

        jLabel11.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel11.setText("PVP:");

        PVPbox.setText("True");

        jLabel12.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel12.setText("Level Name:");

        jLabel13.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel13.setText("Level Type:");

        jLabel14.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel14.setText("Query:");

        Qbox.setText("True");

        jLabel15.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel15.setText("RCON:");

        RCONbox.setText("True");

        jLabel16.setFont(new java.awt.Font("Lucida Grande", 0, 14)); // NOI18N
        jLabel16.setText("RCON Password:");

        SaveButton.setText("Save");
        SaveButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                SaveButtonActionPerformed(evt);
            }
        });

        CancelButton.setText("Cancel");
        CancelButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                CancelButtonActionPerformed(evt);
            }
        });

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .add(41, 41, 41)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jLabel1)
                    .add(jLabel2)
                    .add(jLabel3)
                    .add(jLabel4)
                    .add(jLabel5)
                    .add(jLabel6)
                    .add(jLabel7)
                    .add(jLabel8)
                    .add(jLabel9)
                    .add(jLabel10)
                    .add(jLabel11)
                    .add(jLabel12)
                    .add(jLabel13)
                    .add(jLabel14)
                    .add(jLabel15)
                    .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.TRAILING)
                        .add(SaveButton)
                        .add(jLabel16)))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(layout.createSequentialGroup()
                        .add(Wbox)
                        .addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                    .add(layout.createSequentialGroup()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(SPbox)
                            .add(IPbox1)
                            .add(layout.createSequentialGroup()
                                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                                    .add(MPbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 206, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                                    .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING, false)
                                        .add(SNbox)
                                        .add(Dbox, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 199, Short.MAX_VALUE)
                                        .add(MOTDbox, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 199, Short.MAX_VALUE)
                                        .add(IPbox)))
                                .add(0, 0, Short.MAX_VALUE)))
                        .add(41, 41, 41))
                    .add(layout.createSequentialGroup()
                        .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                            .add(RCONPbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 206, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(RCONbox)
                            .add(Qbox)
                            .add(LTbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 206, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(LNbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 206, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                            .add(PVPbox)
                            .add(Hbox)
                            .add(Gbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 206, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                        .add(0, 0, Short.MAX_VALUE))))
            .add(layout.createSequentialGroup()
                .add(222, 222, 222)
                .add(CancelButton, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 77, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .add(0, 0, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 25, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(SNbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel2, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 25, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Dbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel3, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(MOTDbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel4, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(IPbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(IPbox1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel6, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel5, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Wbox))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel7, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(SPbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(MPbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(org.jdesktop.layout.GroupLayout.TRAILING, jLabel8, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel9, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Gbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel10, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Hbox))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel11, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(PVPbox))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(LNbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(jLabel12, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jLabel13, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(LTbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jLabel14, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(Qbox))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jLabel15, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(RCONbox))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(jLabel16, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 27, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                    .add(RCONPbox, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED, 16, Short.MAX_VALUE)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.BASELINE)
                    .add(SaveButton)
                    .add(CancelButton))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void CancelButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_CancelButtonActionPerformed
        setVisible(false);
    }//GEN-LAST:event_CancelButtonActionPerformed

    private void SaveButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_SaveButtonActionPerformed
        String ppts = getProperties();
        main.PropertiesFile.delete();
        main.PropertiesFile = new File(main.dir + "/server.properties");
        try { 
            main.PropertiesFile.createNewFile();
        } catch (IOException ex) {
            JOptionPane.showMessageDialog(null, "Failed to create new properties file!", "Error", JOptionPane.WARNING_MESSAGE);
            return;
        }
        
        FileWriter writer = null;
        try {
            writer = new FileWriter(main.PropertiesFile);
        } catch (IOException ex) {
            JOptionPane.showMessageDialog(null, "Failed to load file for writing!", "Error", JOptionPane.WARNING_MESSAGE);
        }
        
        for (String ppt : ppts.split("\n")) {
            String line;
            if (ppt.contains("=")) {
                if (PropertiesText.containsKey(ppt.split("=")[0])) {
                    line = ppt.split("=")[0] + "=" + PropertiesText.get(ppt.split("=")[0]).getText();
                }
                else if (PropertiesCheck.containsKey(ppt.split("=")[0])){
                    JCheckBox checkbox = PropertiesCheck.get(ppt.split("=")[0]);
                    if (checkbox.isSelected()) {
                        line = ppt.split("=") + "=on";
                    }
                    else {
                        line = ppt.split("=") + "=off";
                    }
                }
                else {
                    line = ppt;
                }
            }
            else {
                line = ppt;
            }
            
            try {
                writer.write(line + "\n");
                writer.flush();
            } catch (IOException ex) {
                JOptionPane.showMessageDialog(null, "Failed to write to file!", "Error", JOptionPane.WARNING_MESSAGE);
            }
        }
        
    }//GEN-LAST:event_SaveButtonActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton CancelButton;
    private javax.swing.JTextField Dbox;
    private javax.swing.JTextField Gbox;
    private javax.swing.JCheckBox Hbox;
    private javax.swing.JTextField IPbox;
    private javax.swing.JTextField IPbox1;
    private javax.swing.JTextField LNbox;
    private javax.swing.JTextField LTbox;
    private javax.swing.JTextField MOTDbox;
    private javax.swing.JTextField MPbox;
    private javax.swing.JCheckBox PVPbox;
    private javax.swing.JCheckBox Qbox;
    private javax.swing.JTextField RCONPbox;
    private javax.swing.JCheckBox RCONbox;
    private javax.swing.JTextField SNbox;
    private javax.swing.JTextField SPbox;
    private javax.swing.JButton SaveButton;
    private javax.swing.JCheckBox Wbox;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel10;
    private javax.swing.JLabel jLabel11;
    private javax.swing.JLabel jLabel12;
    private javax.swing.JLabel jLabel13;
    private javax.swing.JLabel jLabel14;
    private javax.swing.JLabel jLabel15;
    private javax.swing.JLabel jLabel16;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    // End of variables declaration//GEN-END:variables
}
