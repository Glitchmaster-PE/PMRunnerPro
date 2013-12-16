package com.junyi00;

import java.awt.Dimension;
import java.awt.Font;
import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JScrollPane;
import javax.swing.ListSelectionModel;

public class InfoFrame extends JFrame {
    String text;
    String name;
    
    public InfoFrame(String text, String name) {
        this.text = text;
        this.name = name;
        this.setLocationRelativeTo(null);
        this.setName(name);
        this.setTitle(name);
        
        init();
    }
    
    public void init() {
        this.getContentPane().setLayout(new BoxLayout(this.getContentPane(), BoxLayout.Y_AXIS));
        /*
        String[] line = text.split("\n");
        int x = 0;
        for (int i=0; i<line.length; i++) {
            String str = (i+1) + ")" + line[i];
            JLabel label = new JLabel(str);
            JSeparator spt = new JSeparator(SwingConstants.HORIZONTAL);
            spt.setSize(this.getPreferredSize().width, 1);
            spt.setForeground(Color.black);
            
            add(label);
            
            if (line[i].length() > x) {
                x = line[i].length();
            }
        } */                  //OLD WAY OF SHOWING THE LIST IN THE FRAME
        JLabel label = new JLabel(name);
        label.setFont(new Font("Arial", Font.BOLD, 18));
        add(label);
            
        String[] line = text.split("\n");
        JList list = new JList(line); //data has type Object[]
        list.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        list.setLayoutOrientation(JList.VERTICAL);
        list.setVisibleRowCount(-1);
        JScrollPane listScroller = new JScrollPane(list);
        listScroller.setWheelScrollingEnabled(true);
        listScroller.setPreferredSize(new Dimension(250, 80));
        
        add(listScroller);
        
        setPreferredSize(new Dimension(150, 250));
        pack();
        
        /*
        setPreferredSize(new Dimension(150, (line.length*10+50+(line.length*5))));
        pack(); */
    }
    
}
