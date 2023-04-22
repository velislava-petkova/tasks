import java.util.ArrayList;
import java.util.List;

/*
* First thing we can do is create abstract class for all the workers. This class will create the worker and
* add it to the shop. The getTurnover method is declared as abstract in order to force children to ovverride it.
* This way, when we want to extend the shop we don't need to change the current classes that exist, we only need to
* think of the new classes we are adding.
* */

abstract class Worker{
    protected static Shop workingShop;
    public Worker(){
        this.workingShop =  Shop.getInstance();
        this.workingShop.addWorker(this);
    }

    public abstract double getTurnover();
}

class Shop {
    private static Shop instance;

    //Now we can be more specific and declare the list of type Worker instead of Object
    private List<Worker> workers = new ArrayList();

    public static Shop getInstance() {
        if (instance == null) {
            instance = new Shop();
        }

        return instance;
    }


    public void addWorker(Worker worker) {
        this.workers.add(worker);
    }

    /*
    Our turnover method can now call the getTurnover method of each of the children, when adding new types of workers
    the sum we need to add to the turnover will be handled in the child and the Shop class is simplified and doesn't have
    additional responsibilities.
    */

    public double getTurnover() {
        double turnOver = 0.0;
        for (var worker : this.workers) {
            turnOver+=worker.getTurnover();
        }
        return turnOver;
    }
}


class SalesConsultant extends Worker{
    private double earnedMoney;
    public  SalesConsultant() {
       super();
       this.earnedMoney=0;
    }

    public void sellProduct(double price) {
        this.earnedMoney += Math.max(price, 0);
    }

    public double getMoney() {
        return this.earnedMoney;
    }

    public double getTurnover(){
        return this.earnedMoney;
    }
}

class MarketingSpecialist extends Worker{
    private double budget;

    public MarketingSpecialist() {
        super();
        this.budget=5000.0;
    }

    public void spendMoney(double marketingCampaignCost) {
        double verifiedCost = Math.max(marketingCampaignCost, 0);
        //I think it is better to have verification so that we can't have a negative budget
        //(unless we have this as a requirement for the Shop)

        if(verifiedCost>0){
            if(this.budget>=marketingCampaignCost)
                this.budget -= marketingCampaignCost;
        }

    }

    public double getBudget() {
        return this.budget;
    }

    public double getTurnover(){
        return this.budget;
    }
}
class HelloWorld {
    public static void main(String[] args) {

        //Example
        Shop myShop = Shop.getInstance();
        SalesConsultant worker1 = new SalesConsultant();
        SalesConsultant worker2 = new SalesConsultant();
        MarketingSpecialist worker3 = new MarketingSpecialist();
        MarketingSpecialist worker4 = new MarketingSpecialist();
        worker1.sellProduct(1500);
        worker2.sellProduct(100);
        worker3.spendMoney(5000);
        worker3.spendMoney(5000); //This will not do anything because we have no money to spend here

        double turnover = myShop.getTurnover();
        System.out.println(turnover);
    }
}