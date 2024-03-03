# [Top 7 Unity Architecture Mistakes](https://www.linkedin.com/pulse/top-7-unity-architecture-mistakes-match3games-siarhei-khalandachou-uyklf/)

### **1. Wasteful game-level management**
   
**Symptoms:** You have to resubmit the client to add new game levels in production for players. Your level designers can only add new levels with support from developers with existing game mechanics.
   
Possible Root Causes: I believe your project was developed fast from prototype start-up mode, without taking into account realizing high-quality client architecture standards needed for long-living games in production. The phase of designing the game content management system and the right project structure was skipped.
   
Possible Treatment: For some, it is okay to update the client when adding new content, fight with the stores when updates regularly, and have to allocate too many people in the studio for checking new content. But if you want to free up additional resources for new feature development, you can take a look at Addresables or building an asset bundle custom system and separate game-level content from monolithic game repo code.
   
How it should be: Your level designers can produce and test new levels without game developers. Your LiveOps team can publish new game levels for all client versions independently without producing production incidents. Your players are happy with new regular content without pushing to update their version of the client.

### **2. Abnormal Live Ops activities management**
   
Symptoms: To run fresh Live Ops weekly/monthly activities, you have to resubmit the client. Your Live Ops team can only add new activities with support from developers.
   
Possible Root Causes: Game data/configuration is hardcoded. The design phase for the Live Ops feature management system was skipped. You omitted the design of Live Ops-related content and its support from your product’s life cycle.
   
Possible Treatment: I believe you have to include Live Ops designing and supporting it into your feature development template for all new features. And to plan to rework existing hardcoded items and dependencies on client code with your technical debt in the project iteratively from the most profitable features to less important ones by moving out/extracting them from the client to your back office feature configurations.
   
How it should be: Your live ops team can operate fully independently. Have a convenient back office to manage live ops-related features. Live ops can publish new changes into production for all supported client versions without pushing players to update the client and without affecting the stability of production. You can measure the performance business impact of your Live ops operations in a clear way (ARPU lift, retention changes, welcome back efficiency, etc).

### **3. New release regression takes too much time**
   
Symptoms: Every regression before release is huge. You build for several years a several thousand of game levels. To verify the high quality of everything, you should allocate 10–20 manual QA specials.
   
Possible root causes: It seems to lack tests, and your game has a rigid monolithic component design with a tight coupling of components. If you have automation tests, it might take too much time because most of them are play mode UI-based, or e2e, and it might be a signal of overusing Monobehaviours in your game architecture. A 1000-unit test run will take less time than 1 e2e.
   
Possible Treatment: Building a pyramid of tests. Design and develop tests based on your testing pyramid. Unit Tests at the bottom layer. Integration Tests in the middle layer. End-to-End Tests (E2E) at the top layer. Introduce automation QA and start writing e2e tests based on behavioral test cases. Next, integrate them into your automated regression pipeline.
   
I am confident from my experience that if your project grows from a kind of MVP/prototype, that is pretty hard to introduce unit testing immediately into your development cycle. It is possible to freeze increasing technical debt for existing feature sets and iteratively change the approach of new feature development. One way to achieve technical excellence is to rewrite your project from scratch with a new Unity architect design or plan reworking in a 1–2 year technical roadmap.
   
How it should be: You have full automated client regression at 90%. Your time to market is up to 2 days. You have up to 1 moderate bug after code freeze and 0 critical.

### **4. Inefficient Asset Management**
   
**Symptoms:** Performance lags and OOM crashes in production. FPS drops. Players complain about crashes, micro-freezes, and getting stuck in some game levels.
   
**Possible root causes:** Loading and unloading assets inefficiently can lead to memory leaks and slow down the game. Unoptimized graphics, misleading best practices, and lost target platform performance tests in production,not taking mobile specific considerations; as a result, the game is not optimized for lower-end devices. Might be you were too focused on adding new features or product core and beating the CPI of competitors.
   
**Possible Treatment:** Design and implement an asset management system. Adding profiling to the game before release. Building automated performance testing of clients during development. Building technical performance thresholds related to FPS/memory consumption, disc occupation, etc, for your target-supported platforms per few tiers devices. Plan technical debt to improve hardware usage from a GPU/CPU/Network perspective. The easiest significant benefit you can achieve by using the right texture compression per platform plus introducing sprite atlases per features.
   
**How it should be:** Your players can play the game for a few hours without OOM crashes, performance lags, and fps drops. You have automated performance profiling in your QA pipeline and during regular development. Your technical performance metrics in production are not over the store's thresholds and are significantly better than your competitors.

### **5. Rigid client design limitations**
   
**Symptoms:** The current architecture design makes it slow to add new features or make changes. Team estimates seem fantastic for simple product changes, and they continue increasing over months of development. That takes too much time from your development capacity and produces bugs when adding new features or making core mechanic changes.
   
**Possible root causes:** It seems your game has a rigid monolithic component design with a tight coupling of components. When a developer has to add changes, that affects too many components, and it can impact other components in unpredictable ways.
   
**Possible Treatment:** It looks like you have technical debt related to the core design of your client. You have to evaluate the current architecture of client systems and plan to shift from monolithic to use modular design principles.
   
Consider state machines for clarity and organization. And, of course, keep game logic separate from the UI presentation layer. Even a basic MV* approach will improve your state.
   
**How it should be:** to add new meta feature from concept to production up to 2 sprints, to change core mechanic up to 1 sprint.

### **6. Lack of architectural stability**
   
**Symptoms:** Flaky bugs in production. From your end, everything works as expected, and 10–20 QA says everything is good, but in production, you see from analytics an suspicious deviations rate of fail/win ratio or not ending of some levels in ratio 1–2/1000 launches per a specific segment.
   
**Possible root causes:** Here I can name too many possible variations of reasons but from my experience will highlight my top: Client architecture is rigid monolithic, Poor Input Handling, Game logic is not separated from UI presentation, Core engine being based on Unity Physics and overcomplicated, Game mechanics built on overusing MonoBehaviours/GameObjects, Omitting Proper State Management.
   
**Some special advice:** DON’T USE UNITY PHYSICS FOR MATCH 3 GAMES. It is okay for POC/MVP/Prototype, but if you are going to guarantee 100% predictability of 1 mln launches of game levels on all devices, that is too risky to implement moving/interactions of pieces based on unity physics. Internally, unity physics is deterministic in engine, but because it is based on float arithmetic, it is hard to achieve the same end result of physics interactions on different target platforms. Unity forum link
   
**Possible Treatment:** You can easily spend a lot of resources to solve your flaky bugs. If you do not have the resources to rework a design client from scratch or are limited with time to improve production stability level with iterative improvements based on technical backlog, you can increase your chances of fixing the flaky bugs. You should somehow get a repro of this. To achieve it, you can build simulation tools and be able to thousand of times to replay some levels automatically, really fast. When you get repro of the flaky bug you can check new changes and increase confidence about end quality. Next basic pieces of advice for your technical debt: keep game logic separate from UI presentation, and use event-driven communication or dedicated UI controllers for flexibility and testing.
   
**How it should be:** You have almost zero flaky bugs in production. The architecture of the client allows you to apply product changes while getting a high level of predictability from time spent on implementation and business KPIs feedback from production.

### **7. Improper project structure organization**
   
**Symptoms:** Client and content build time takes a few hours. Art/level designer teams complain about a mess with assets. Your level designers and art team members complain about the slowness of the project and too much time wasted preparing for new content or even about a mess with assets. Unity Editor is becoming unresponsive and can crash simultaneously.
   
**Possible root causes:** I believe you have all the art content inside one Unity project. Your asset database takes a few gigabytes and continues to grow. That might happen because you started the project from MVP/Prototype state and continued developing and adding art resources. You skipped the design project structure architecture and did not take an approachable template for the game.
   
**Possible Treatment:** Break down the monolithic Unity project into smaller, manageable projects. Common components, code, and assets should be extracted into Unity packages. These shared Unity packages can be used across different projects, ensuring reusability and consistency. Design content management and structure organization architecture for your project and plan reworking existing technical debt.
   
**How it should be:** The project structure organization should facilitate both efficiency in build times for clients and content and ease of use for the development team, particularly for art and level designers. From my experience, up to 20 minutes to build client and content is acceptable. Unity Editor is responsive when adding new content over time.
   
## In conclusion
   
I believe that to be at the top of the grossing charts, you have to make technical excellence your top priority from the beginning of development. If you built a successful MVP/prototype, let’s sit down and design an approachable client architecture vision and think about the content management system and Live ops as early as possible. It will save investments money in the future and help to overcome hard times.